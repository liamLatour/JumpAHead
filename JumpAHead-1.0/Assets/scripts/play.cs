using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{

    public void Play(int lvl)
    {
        SceneManager.LoadScene(lvl);
    }
}
