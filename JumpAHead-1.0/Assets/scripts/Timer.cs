using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

    public float starttime;
    public float time = 10;
    public Text timme;
    public bool finished = false;
    public Transform end;
    public GameObject pause;

    public Text p1;
    public Text p2;

    public Text pm1;
    public Text pm2;

    public Text end1;
    public Text end2;

    public GameObject crown1;
    public GameObject crown2;
    
    private int turns;

    public Transform replay;
    public Transform menu;

    void Start () {
        turns = changeNb.turn;
        starttime = Time.time;
    }
	
    //Go back to main menu after turns

        
	void Update () {
        float cur = Time.time - starttime;

        if (Mathf.Round(time - cur) < 0 && !finished)
        {
            if (int.Parse(p1.text) == int.Parse(p2.text))
            {
                starttime = Time.time - (time - 10);
            }
            else
            {
                finished = true;
                end.gameObject.SetActive(true);

                if (int.Parse(p1.text) > int.Parse(p2.text))
                {
                    pm1.text = (int.Parse(pm1.text) + 1).ToString();
                    crown1.SetActive(true);
                    crown2.SetActive(false);
                }
                else
                {
                    pm2.text = (int.Parse(pm2.text) + 1).ToString();
                    crown1.SetActive(false);
                    crown2.SetActive(true);
                }

                end1.text = pm1.text;
                end2.text = pm2.text;

                if (int.Parse(end1.text) == turns)
                {
                    replay.gameObject.SetActive(false);
                    menu.gameObject.SetActive(true);

                    crown1.transform.localScale = new Vector3(1.5f, 1.5f, 1);
                    crown1.transform.Translate(Vector3.left * 10);
                    crown1.transform.Rotate(Vector3.forward * 10);
                }

                if (int.Parse(end2.text) == turns)
                {
                    replay.gameObject.SetActive(false);
                    menu.gameObject.SetActive(true);

                    crown2.transform.localScale = new Vector3(1.5f, 1.5f, 1);
                    crown2.transform.Translate(Vector3.left * 10);
                    crown2.transform.Rotate(Vector3.forward * 10);
                }
            }
        }
        else if (!finished)
        {
            timme.text = (Mathf.Round(time - cur)).ToString();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !end.gameObject.activeSelf)
        {
            if (Time.timeScale == 1)
            {
                finished = true;
                pause.SetActive(true);
                Time.timeScale = 0.00001f;
            }
            else
            {
                finished = false;
                pause.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}
}