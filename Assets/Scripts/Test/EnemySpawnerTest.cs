using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int period;
    [SerializeField] private GameObject target;
    private float time = 0;

    [SerializeField] private int poolSize = 0;


    //List<GameObject> enemyPool = new List<GameObject>();
    public Queue<GameObject> enemyPool = new Queue<GameObject> ();


    void Start()
    {

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(target);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
        }
        Debug.Log(enemyPool.Count);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //if (time >= period)
        //{
        //    GameObject enemy = Instantiate(target);
        //    enemy.transform.position = new Vector3 (Random.Range(0, 9), enemy.transform.position.y, enemy.transform.position.z);
        //    time = 0;
        //}

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (enemyPool.Count > 0)
            {
                GameObject gameObject = enemyPool.Dequeue();
                gameObject.transform.position = new Vector3 (Random.Range(0, 9), 0, 0);
                gameObject.SetActive(true);
            }
        }
        Debug.Log(enemyPool.Count);
    }
}
