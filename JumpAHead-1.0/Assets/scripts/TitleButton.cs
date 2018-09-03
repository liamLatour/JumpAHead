using UnityEngine;

public class TitleButton : MonoBehaviour
{
    private bool hover;
    private Vector3 big;

    public Vector3 small;

    public Animator anim;


    private void Awake()
    {
        big = transform.localScale;
    }

    void Update()
    {
        transform.localScale = big - small;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.collider.CompareTag("title"))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    anim.SetTrigger("retour");
                    anim.ResetTrigger("duo");
                    anim.ResetTrigger("solo");
                }

                transform.localScale = big;
            }
        }
    }
}