using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;   


public class ScoreController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static int score = 0;
    private const string BestScoreKey = "BestScore";
    private const string CurrentScoreKey = "CurrentScore";

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    Text txtPause;
    bool isRunning;
    void Start()
    {
        isRunning = true;
        if(scoreText == null)
        {
            Debug.LogError("Score Text is not assigned");
            scoreText = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
            score = 0;
        }
        else
        {
            scoreText.text = "Score: " + score;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }

    public void PauseGame()
    {
        isRunning = !isRunning;
        if (isRunning)
        {
            Time.timeScale = 1;
            txtPause.text = "Pause";
        }
        else
        {
            Time.timeScale = 0;
            txtPause.text = "Resume";
        }
    }


    public static void SaveCurrentScore()
    {
        PlayerPrefs.SetInt(CurrentScoreKey, score);
        PlayerPrefs.Save();
    }

    public static void SaveBestScore()
    {
        int bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, score);
            PlayerPrefs.Save();
        }
    }

    public static int GetCurrentScore()
    {
        return PlayerPrefs.GetInt(CurrentScoreKey, 0);
    }


    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0);
    }
}
