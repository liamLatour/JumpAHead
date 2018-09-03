using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput1 : MonoBehaviour
{
    

    private Player player;
    private Abiliti abiliti;
    public Abiliti[] abilities;

    private void Start()
    {
        player = GetComponent<Player>();

        abiliti = abilities[PlayerPrefs.GetInt("P2")];

        player.moveSpeed = abiliti.speed;
        player.timeToJumpApex = abiliti.jump;
        player.maxJumpHeight = abiliti.jumpHeight;
    }

    private void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal1"), Input.GetAxisRaw("Vertical1"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            player.OnJumpInputUp();
        }
    }
}