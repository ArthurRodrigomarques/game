using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public int numberPhase;

    public void ButtonStart()
    {
        Invoke("LoadGame", 2.0f);
    }

    void LoadGame()
    {
       SceneManager.LoadScene(numberPhase); 
    }
}
