using UnityEngine.UI;
using UnityEngine;

public class replay : MonoBehaviour {

    public Transform end;

    public DuoWINNING w1;
    public DuoWINNING w2;

    public Text sc1;
    public Text sc2;

    public Transform p1;
    public Transform p2;

    public Timer tim;

    public void Reload()
    {
        end.gameObject.SetActive(false);

        w1.score = 0;
        w2.score = 0;

        sc1.text = "0";
        sc2.text = "0";

        p1.position = new Vector3(7, -4, 0);
        p2.position = new Vector3(-7, -4, 0);

        tim.starttime = Time.time;
        tim.finished = false;
    }
}