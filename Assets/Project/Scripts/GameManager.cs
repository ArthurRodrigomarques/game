using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    // vida do player
    public Slider sliderLife;
    public static GameManager instance;

    // Pause
    public GameObject painelMenu;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // vida
        sliderLife.maxValue = 100; // A vida inicial máxima
        sliderLife.value = 100;

        // pause
        painelMenu.SetActive(false);
    }

    public void UpdateLifeSlider(int currentLife)
    {
        sliderLife.value = currentLife;
    }

    void Update()
    {
        Pause();
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & Time.timeScale == 1) 
        {
            Time.timeScale = 0;
            painelMenu.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) & Time.timeScale == 0)
        {
            Time.timeScale = 1;
            painelMenu.SetActive(false);
        }
    }
}
