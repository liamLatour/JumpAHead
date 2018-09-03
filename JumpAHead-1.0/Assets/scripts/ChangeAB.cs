using UnityEngine.UI;
using UnityEngine;

public class ChangeAB : MonoBehaviour {

    public Text disp;
    private int nb;

    public Abiliti[] abilities;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("P1") || !PlayerPrefs.HasKey("P2"))
        {
            PlayerPrefs.SetInt("P1", 0);
            PlayerPrefs.SetInt("P2", 0);
        }

        if (transform.parent.name == "P1")
        {
            disp.text = abilities[PlayerPrefs.GetInt("P1")].name;
        }
        else
        {
            disp.text = abilities[PlayerPrefs.GetInt("P2")].name;
        }
    }

    public void Up()
    {
        nb++;
        if (nb > abilities.Length-1)
        {
            nb = 0;
        }

        disp.text = abilities[nb].name;
        PlayerPrefs.SetInt(transform.parent.name, nb);
    }

    public void Down()
    {
        nb--;
        if (nb < 0)
        {
            nb = abilities.Length-1;
        }
        disp.text = abilities[nb].name;
        PlayerPrefs.SetInt(transform.parent.name, nb);
    }
}
