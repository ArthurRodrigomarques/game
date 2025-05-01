using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class GameManager : MonoBehaviour
{
    // vida do player
    public Slider sliderLife;
    public static GameManager instance;

    // Pause
    public GameObject painelMenu;

    // Game Over
    public GameObject painelGameOver;
    // video Game Over
    public VideoPlayer gameOverVideo;

    public PlayerLife playerLife;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // vida
        sliderLife.maxValue = 100;
        sliderLife.value = 100;

        // pause
        painelMenu.SetActive(false);

        // game over
        painelGameOver.SetActive(false);
    }


    // update da vida do player
    public void UpdateLifeSlider(int currentLife)
    {
        sliderLife.value = currentLife;
    }

    // mostrar o game over quando o player morrer
    public void ShowGameOver()
    {
        painelGameOver.SetActive(true);
        Time.timeScale = 0;

        if (gameOverVideo != null)
            gameOverVideo.Play();
    }

    void Update()
    {
        Pause();
    }


    // quando apertar Esc pausar o jogo
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            painelMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0 && !painelGameOver.activeSelf)
        {
            Time.timeScale = 1;
            painelMenu.SetActive(false);
        }
    }

    // botão para reiniciar a fase
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Continuar()
    {
        painelGameOver.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.UpdateLifeSlider(100);

        var player = Player._Player;
        var playerLife = player.GetComponent<PlayerLife>();

        playerLife.life = 100;
        playerLife.death = false;
        player.transform.position = playerLife.initialPosition;
        player.canMove = true;

        Animator anim = player.GetComponent<Animator>();
        anim.Rebind();
        anim.Update(0f);
    }



    public void VoltarMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
}
