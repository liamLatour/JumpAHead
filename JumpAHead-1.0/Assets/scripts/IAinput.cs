using UnityEngine;

[RequireComponent(typeof(Player))]
public class IAinput : MonoBehaviour {

    private Player player;
    private Controller2D controll;
    private Controller2D mycontroll;
    public Transform OthPlayer;
    public float random;
    private bool moved = false;

    int x = 0; // -1 or 0 or 1
    int y = 0; //0 or -1
    bool jump = false;
    bool quitJump = false;

    private void Start()
    {
        player = GetComponent<Player>();
        controll = OthPlayer.gameObject.GetComponent<Controller2D>();
        mycontroll = transform.gameObject.GetComponent<Controller2D>();
    }

    private void Randomize(float rand)
    {
        if (Random.value < rand)
        {
            x = Random.Range(-1, 1);
        }
        if (Random.value < rand)
        {
            y = Random.Range(-1, 0);
        }
        if (Random.value < rand)
        {
            jump = (Random.value < 0.5f);
        }
        if (Random.value < rand)
        {
            quitJump = (Random.value < 0.5f);
        }
    }

    private void GoTo(float xx)
    {
        if (Mathf.Abs(transform.position.x - xx) < 0.5f)
        {
            x = 0;
        }
        else
        {
            if (transform.position.x - xx > 0)
            {
                x = -1;
            }
            else
            {
                x = 1;
            }
        }
    }

    private void Update()
    {
        if (!moved)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonUp("Jump") || Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") !=0)
            {
                moved = true;
            }
            else
            {
                return;
            }            
        }


        //Horizontal for left and right
        //Vertical to pass through platform
        //Down to jump
        //Up to exit jump

        float xdif = transform.position.x - OthPlayer.position.x;
        float ydif = transform.position.y - OthPlayer.position.y;

        //Avoids 'under platform' bug
        if (OthPlayer.position.y > 0 || (controll.OnAPlatform && OthPlayer.position.y > -1))
        {
            if (OthPlayer.position.x < 0)
            {
                GoTo(OthPlayer.position.x + 3);
            }
            else
            {
                GoTo(OthPlayer.position.x - 3);
            }

            jump = false;
            quitJump = true;
            y = -1;

            //Avoids to be hit
            if (Mathf.Abs(xdif) < 2 && ydif < 0 && ydif > -6)
            {
                x = -x;
            }
        }
        else if (mycontroll.OnAPlatform && ydif > 0)
        {
            x = 0;
            jump = false;
            quitJump = false;
            y = 0;

            if (ydif < 3)
            {
                y = -1;
            }
        }
        else
        {
            if (xdif < 0)
            {
                x = 1;
            }
            else
            {
                x = -1;
            }

            //tries to be on top of player
            if (ydif < 2 && Mathf.Abs(xdif) < 3)
            {
                if (jump == false)
                {
                    jump = true;
                    quitJump = false;
                    y = 0;
                }
                else
                {
                    jump = false;
                }
            }
            else
            {
                jump = false;
                quitJump = true;
                y = -1;
            }

            //Avoids to be hit
            if (Mathf.Abs(xdif) < 2 && ydif < 0 && ydif > -3)
            {
                jump = false;
                quitJump = true;
                y = -1;
                x = -x;
            }
        }

        //Avoids spikes
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(8.6f, 4.6f)) < 1.5f)
        {
            jump = false;
            quitJump = true;
            y = -1;
            x = -1;
        }
        //Avoids spikes
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(-8.6f, 4.6f)) < 1.5f)
        {
            jump = false;
            quitJump = true;
            y = -1;
            x = 1;
        }

        //Randomize(random);

        Vector2 directionalInput = new Vector2(x, y);
        player.SetDirectionalInput(directionalInput);

        if (jump)
        {
            player.OnJumpInputDown();
        }

        if (quitJump)
        {
            player.OnJumpInputUp();
        }
    }
}
