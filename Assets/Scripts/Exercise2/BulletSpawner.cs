using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int bulletPoolSize = 50;
    [SerializeField] GameObject target;
    [SerializeField] GameObject gunBody;
    [SerializeField] GameObject gunBarell;
    Queue<GameObject> bulletPool = new Queue<GameObject>();

    private Vector2 direction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(target);
            if (bullet != null)
            {
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
        }
        
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnBullet(Vector2 direction, float speed)
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive (true);
            bullet.transform.position = gunBarell.transform.position;
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
        }
    }
}
