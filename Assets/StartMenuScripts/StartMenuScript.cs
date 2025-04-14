using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScript : MonoBehaviour
{
    [SerializeField] AudioSource audio;

    private void Awake()
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
}
