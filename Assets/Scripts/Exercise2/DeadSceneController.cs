using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DeadSceneController : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int currentScore = ScoreController.GetCurrentScore();
        int bestScore = ScoreController.GetBestScore();

        bestScoreText.text = $"Best Score: {bestScore}";
        currentScoreText.text = $"Score: {currentScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Restart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
