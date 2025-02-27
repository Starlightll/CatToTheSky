using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image fillImage;
    public float maxHealth = 100;
    public float currentHealth;
    [SerializeField] GameObject player;
    public float timeBeforeNextScene = 3f;
    public AudioSource deathSound;

    [Header("Explosion Setting")]
    public GameObject explosionPrefab;
    public float destroyTime = 5f;
    
    private bool isAlive;

    private void Start()
    {
        currentHealth = maxHealth;
        isAlive = true;
        UpdateHealthBar();
    }


    private void Update()
    {
        if (currentHealth <= 0 && isAlive)
        {
            isAlive = false;
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
        
        GameObject explosion = Instantiate(explosionPrefab, player.transform.position, Quaternion.identity);
        explosion.transform.position = player.transform.position;
        Destroy(explosion, destroyTime);
        if (deathSound != null)
            deathSound.Play();
        ScoreController.SaveCurrentScore();
        ScoreController.SaveBestScore();
        ScoreController.score = 0;
        SceneManager.LoadScene("DeadScene");
    }

   



}
