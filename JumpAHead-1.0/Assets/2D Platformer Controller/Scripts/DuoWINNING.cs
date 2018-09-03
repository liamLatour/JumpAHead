using UnityEngine;
using UnityEngine.UI;

public class DuoWINNING : MonoBehaviour {

    public GameObject win;
    public int score = 0;
    public Text mescore;

    public bool cantWin;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spikes")
        {
            score--;
        }

        if (collision == win.GetComponent<Collider2D>() && !cantWin)
        {
            score++;

            win.transform.parent.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play();
        }
       
        mescore.text = score.ToString();
    }
}
