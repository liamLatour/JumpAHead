using UnityEngine;
using UnityEngine.UI;

public class WINNING : MonoBehaviour {
    
    public GameObject win;
    public int score = 0;
    public Text mescore;


    //score has to be larger (0 to 100) rather than 0 to 2


    private void Awake()
    {
        if (this.transform.parent.name != "Player")
        {
            win = GameObject.Find("Player/win");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spikes")
        {
            score--;

            if (this.transform.parent.name == "Player")
            {
                mescore.text = score.ToString();
            }
        }

        if (this.transform.parent.name != "Player")
        {
            if (collision == win.GetComponent<Collider2D>())
            {
                score++;
            }
        }
        else if (collision.tag == "ennemy")
        {
            score++;
            mescore.text = score.ToString();
        }
    }
}
