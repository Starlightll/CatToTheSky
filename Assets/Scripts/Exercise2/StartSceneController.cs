using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited");
    }
}
