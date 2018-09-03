using UnityEngine;
using UnityEngine.UI;

public class WinParticle : MonoBehaviour {

    private ParticleSystem.EmissionModule myParticleSystem;
    public Text myPoints;
    public Text hisPoints;
    public int nb = 10;

	// Use this for initialization
	void Start () {
        myParticleSystem = GetComponent<ParticleSystem>().emission;
	}
	
	// Update is called once per frame
	void Update () {
        myParticleSystem.rateOverTime = Mathf.Round((float)Mathf.Max(int.Parse(myPoints.text), 1) / ((float)Mathf.Max(int.Parse(myPoints.text), 1) + (float)Mathf.Max(int.Parse(hisPoints.text), 1)) * nb);
	}
}