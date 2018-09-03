using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public GameObject pause;
    public Timer timesc;

    public void Pause()
    {
        timesc.finished = false;
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}
