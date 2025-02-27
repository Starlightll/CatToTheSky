using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image fillImage;
    public float maxHealth = 100;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }


    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }



    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        fillImage.fillAmount = currentHealth / maxHealth;
    }


    void Die()
    {
        ScoreController.SaveCurrentScore();
        ScoreController.SaveBestScore();
        SceneManager.LoadScene("DeadScene");
    }



}
