using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private int score = 0;

    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    void Start()
    {
        UpdateScore();

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
        scoreText.text = "Score: " + score.ToString();
    }
}
