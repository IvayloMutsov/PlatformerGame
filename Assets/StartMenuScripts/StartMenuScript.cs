using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    public GameObject instructions;

    void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio.Play();
    }

    public void Play()
    {
        SceneManager.LoadScene("Gameplay",LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowInstructions()
    {
        if (instructions.activeSelf == true)
        {
            instructions.SetActive(false);
        }
        else
        {
            instructions.SetActive(true);
        }
    }
}
