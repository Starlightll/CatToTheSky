using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 direction;
    private float speed = 5f;
    EnemySpawner enemySpawner;
    HealthController healthController;
    private bool isHit = false;


    public void setSpeed(float Speed)
    {
        this.speed = Speed;
    }


    public void setIsHit(bool isHit)
    {
        this.isHit = isHit;
    }

    



    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        healthController = FindFirstObjectByType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaySceneController.isPaused) return;
        rb.linearVelocity = direction.normalized * speed;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isHit) return;

        if(collision.CompareTag("PlayerAreaBottomLine"))
        {
            enemySpawner.DeactiveEnemy(gameObject);
            healthController.TakeDamage(5);
            return;
        }

        if (collision.CompareTag("Missile"))
        {
            isHit = true;
            enemySpawner.KillEnemy(gameObject);
            Destroy(collision.gameObject);
            return;
        }
        //if (collision.CompareTag("Player"))
        //{
        //    enemySpawner.DeactiveEnemy(collision.gameObject);
        //}
    }
}
