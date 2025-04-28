using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider sliderLife;
    public static GameManager instance; // Singleton para facilitar acesso

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        sliderLife.maxValue = 100; // A vida inicial máxima
        sliderLife.value = 100;
    }

    public void UpdateLifeSlider(int currentLife)
    {
        sliderLife.value = currentLife;
    }
}
