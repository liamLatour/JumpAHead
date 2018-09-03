using UnityEngine;

public class displayBut : MonoBehaviour {
    
    public Animator anim;

    public void Show()
    {
        if (transform.name == "Duo")
        {


            anim.ResetTrigger("retour");
            anim.SetTrigger("duo");
            anim.ResetTrigger("solo");
        }
        else
        {
            anim.ResetTrigger("retour");
            anim.ResetTrigger("duo");
            anim.SetTrigger("solo");
        }
    }
}
