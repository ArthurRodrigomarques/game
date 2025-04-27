using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScene : MonoBehaviour
{
    public int numberPhase;

    void Start()
    {
        Invoke("LoadGame", 2.0f); 
    }

    void LoadGame()
    {
        SceneManager.LoadScene(numberPhase);
    }
}
