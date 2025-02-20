using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int score = 0;

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        if(scoreText == null)
        {
            Debug.LogError("Score Text is not assigned");
            scoreText = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
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
}
