using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 direction;
    [SerializeField] float speed = 5f;
    EnemySpawner enemySpawner;
    HealthController healthController;



    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
        healthController = FindFirstObjectByType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = direction.normalized * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerAreaBottomLine"))
        {
            enemySpawner.DeactiveEnemy(gameObject);
            healthController.TakeDamage(5);

        }
        //if (collision.CompareTag("Player"))
        //{
        //    enemySpawner.DeactiveEnemy(collision.gameObject);
        //}
    }
}
