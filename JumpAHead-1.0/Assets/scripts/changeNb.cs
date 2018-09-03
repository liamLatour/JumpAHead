using UnityEngine;
using UnityEngine.UI;

public class changeNb : MonoBehaviour
{
    public Text disp;
    public static int turn = 1;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Up()
    {
        turn++;
        if (turn > 9)
        {
            turn = 9;
        }
        disp.text = turn.ToString();
    }

    public void Down()
    {
        turn--;
        if (turn < 1)
        {
            turn = 1;
        }
        disp.text = turn.ToString();
    }
}