using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winScreen;
    [SerializeField] AudioSource audio;
    Renderer renderer;
    private Image pauseButton;
    public Sprite goSprite;
    public Sprite pauseSprite;
    public Text healthText;

    void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
        pauseButton = GameObject.Find("PauseButton").GetComponent<Image>();
        renderer = GameObject.Find("Body").GetComponent<Renderer>();
        healthText = GameObject.Find("HealthValue").GetComponent<Text>();
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    void Start()
    {
        audio.Play();
    }

    void Update()
    {
        bool canIseeMyPlayer = IsPlayerVisible();
        if (canIseeMyPlayer == false && Time.realtimeSinceStartup > 3f || int.Parse(healthText.text) <= 0)
        {
            healthText.text = "0";
            LoseGame();
            pauseButton.gameObject.SetActive(false);
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
        gameOverScreen.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void WinGame()
    {
        winScreen.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    bool IsPlayerVisible()
    {
        return renderer.isVisible;
    }
}
