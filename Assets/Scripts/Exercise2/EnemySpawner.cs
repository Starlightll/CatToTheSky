using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private float spawnRadius = 1f;
    private float spawnTimer = 0f;
    [SerializeField] private float spawnTimerMax = 1f;
    [SerializeField] int enemyPoolSize = 100;
    private Queue<GameObject> enemies = new Queue<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(0, 0), Quaternion.identity);
            enemy.SetActive(false);
            enemies.Enqueue(enemy);
        }
    }


    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTimerMax && enemyPoolSize > 0)
        {
            spawnTimer = 0f;
            GameObject enemy = enemies.Dequeue();
            enemy.SetActive(true);
            enemy.transform.rotation = Quaternion.Euler(0, 0, 180);
            enemy.transform.position = new Vector2(Random.Range(-spawnRadius, spawnRadius), 6);

        }
    }

    public void DeactiveEnemy(GameObject enemy)
    {
        enemies.Enqueue(enemy);
        enemy.SetActive(false);
    }

}
