using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int numberPhase;

    public void ButtonStart()
    {
        SceneManager.LoadScene("Load");
    }
}
