using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 10f;
    [SerializeField] int bulletPoolSize = 50;
    public Queue<GameObject> bulletPool = new Queue<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
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
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletPool.Count > 0)
            {
                Shoot();

            }
        }
    }

    void Shoot()
    {
            GameObject bullet = bulletPool.Dequeue();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.SetActive(true);
            rb.linearVelocity = firePoint.up * bulletSpeed;
    }

    public void DeactiveBullet(GameObject bullet)
    {
        
        bulletPool.Enqueue(bullet);
        bullet.SetActive(false);
        //Debug.Log("Bullet out of area");
    }
}
