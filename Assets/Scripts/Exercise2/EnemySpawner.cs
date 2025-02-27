using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float spawnRadius = 1f;
    public float enemySpeed = 5f;
    private float spawnTimer = 0f;
    [SerializeField] private float spawnTimerMax = 1f;
    [SerializeField] int enemyPoolSize = 100;
    private Queue<GameObject> enemies = new Queue<GameObject>();

    private ScoreController scoreController;


    [Header("Explosion Setting")]
    public GameObject explosionPrefab;
    public float destroyTime = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        scoreController = FindFirstObjectByType<ScoreController>();
        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(0, 0), Quaternion.identity);
            enemy.SetActive(false);
            enemies.Enqueue(enemy);
        }
    }


    private void Update()
    {
        if (PlaySceneController.isPaused) return;
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTimerMax && enemyPoolSize > 0)
        {
            spawnTimer = 0f;
            GameObject enemy = enemies.Dequeue();
            enemy.SetActive(true);
            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            enemyMovement.setIsHit(false);
            enemyMovement.setSpeed(enemySpeed);
            enemy.transform.rotation = Quaternion.Euler(0, 0, 180);
            enemy.transform.position = new Vector2(Random.Range(-spawnRadius, spawnRadius), transform.position.y);

        }
    }

    public void DeactiveEnemy(GameObject enemy)
    {
        enemies.Enqueue(enemy);
        GameObject explosion = Instantiate(explosionPrefab, enemy.transform.position, Quaternion.identity);
        explosion.transform.position = enemy.transform.position;
        Destroy(explosion, destroyTime);
        enemy.SetActive(false);
    }


 
    public void KillEnemy (GameObject gameObject)
    {
        try
        {
            DeactiveEnemy(gameObject);
            scoreController.AddScore(1);
        }
        catch
        {
            Debug.Log("ScoreController not found");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 from = new Vector3(transform.position.x - spawnRadius, transform.position.y, 0);
        Vector3 to = new Vector3(transform.position.x + spawnRadius, transform.position.y, 0);
        Gizmos.DrawLine(from, to);
    }

}
