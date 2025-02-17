using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    
    public float lifeTime = 3f;
    private GunController gunController;
    private EnemySpawner enemySpawner;
    private ScoreController scoreController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunController = FindFirstObjectByType<GunController>();
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        scoreController = FindFirstObjectByType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            gunController.DeactiveBullet(gameObject);
            enemySpawner.DeactiveEnemy(collision.gameObject);
            scoreController.AddScore(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerArea"))
        {
            gunController.DeactiveBullet(gameObject);
        }
    }



}
