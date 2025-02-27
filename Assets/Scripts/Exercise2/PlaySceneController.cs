using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlaySceneController : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public static bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayScene");
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }
}
