using UnityEngine;
using UnityEngine.UI;

public class passNb : MonoBehaviour
{
    public Text disp;
    public bool left;

    void Start () {
        if (left)
        {
            disp.text = changeNb.turn.ToString() + ':';
        }
        else
        {
            disp.text = ':' + changeNb.turn.ToString();
        }
	}
}