using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public enum DashState { Dashing, Cooldown, Ready};
    public enum Joueur { un, deux };
    public Joueur playerNb;

    private Player player;
    private Abiliti abiliti;
    public Abiliti[] abilities;

    private bool up;
    private bool down;
    private float left;
    private float right;

    private bool tapping;
    private float LastTap;
    public float tapTime = 0.2f;
    private bool isUsed;

    private Rigidbody2D rb;
    private DashState dashState;
    private float dashTimer;
    public float maxDash = 20f;
    public float dashSpeed;
    private Vector2 savedVelocity;

    public ParticleSystem reload;

    public DuoWINNING winning;

    private void Awake()
    {
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();

        if (playerNb == Joueur.un)
        {
            abiliti = abilities[PlayerPrefs.GetInt("P1")];
        }
        else if (playerNb == Joueur.deux)
        {
            abiliti = abilities[PlayerPrefs.GetInt("P2")];
        }

        player.moveSpeed = abiliti.speed;
        player.timeToJumpApex = abiliti.jump;
        player.maxJumpHeight = abiliti.jumpHeight;
    }

    private void Update()
    {
        //Horizontal for left and right
        //Vertical to pass through platform
        //Down to jump
        //Up to exit jump

        if (playerNb == Joueur.un)
        {
            down = Input.GetButtonDown("Jump");
            up = Input.GetButtonUp("Jump");

            left = Input.GetAxisRaw("Horizontal");
            right = Input.GetAxisRaw("Vertical");
        }
        else if (playerNb == Joueur.deux)
        {
            down = Input.GetKeyDown(KeyCode.UpArrow);
            up = Input.GetKeyUp(KeyCode.UpArrow);

            left = Input.GetAxisRaw("Horizontal1");
            right = Input.GetAxisRaw("Vertical1");
        }

        #region Dashing
        switch (dashState)
        {
            case DashState.Ready:
                var isDashKeyDown = doubleTap(left != 0);
                if (isDashKeyDown)
                {
                    savedVelocity = rb.velocity;
                    rb.velocity = new Vector2(left, 0) * dashSpeed;
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime*10f;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    rb.velocity = savedVelocity;
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime/10f;
                if (dashTimer <= 0)
                {
                    // burst particle
                    reload.Play();

                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
        #endregion Dashing

        #region Shield

        #endregion Shield

        Vector2 directionalInput = new Vector2(left, right);
        player.SetDirectionalInput(directionalInput);

        if (down)
        {
            player.OnJumpInputDown();
        }

        if (up)
        {
            player.OnJumpInputUp();
        }
    }


    bool doubleTap(bool tap)
    {
        if (tap)
        {
            if (isUsed == false)
            {
                //checking double tap
                if (tap)
                {
                    if (!tapping)
                    {
                        tapping = true;
                        SingleTap();
                    }
                    if ((Time.time - LastTap) < tapTime)
                    {
                        tapping = false;
                        return true;
                    }
                    LastTap = Time.time;
                }

                isUsed = true;
            }
        }
        else
        {
            isUsed = false;
        }
        
        return false;
    }

    IEnumerator SingleTap()
    {
        yield return new WaitForSeconds(tapTime);
        if (tapping)
        {
            tapping = false;
        }
    }
}
