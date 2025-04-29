using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winScreen;
    [SerializeField] AudioSource audio;
    private Image pauseButton;
    public Sprite goSprite;
    public Sprite pauseSprite;
    public Text healthText;

    void Awake()
    {
        if (audio == null)
            audio = GetComponent<AudioSource>();

        if (pauseButton == null)
            pauseButton = GameObject.Find("PauseButton")?.GetComponent<Image>();

        if (healthText == null)
            healthText = GameObject.Find("HealthValue")?.GetComponent<Text>();

        if (gameOverScreen == null)
            gameOverScreen = GameObject.Find("GameOverScreen");

        if (winScreen == null)
            winScreen = GameObject.Find("WinScreen");

        Time.timeScale = 1;
    }

    void Start()
    {
        audio.Play();
    }

    void Update()
    {
        if (int.Parse(healthText.text) <= 0)
        {
            LoseGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        if (Time.timeScale != 0)
        {
            pauseButton.sprite = goSprite;
            Time.timeScale = 0;
        }
        else
        {
            pauseButton.sprite = pauseSprite;
            Time.timeScale = 1;
        }
    }

    public void LoseGame()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            Time.timeScale = 0;
            healthText.text = "0";
        }
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
    }
}
