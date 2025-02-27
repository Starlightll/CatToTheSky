using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] int bulletPoolSize = 50;
    [SerializeField] GameObject target;
    [SerializeField] GameObject gunBody;
    [SerializeField] GameObject gunBarret;
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
        if (PlaySceneController.isPaused) return;
        if (Input.GetMouseButtonDown(0))
        {
            direction = gunBody.transform.position - gunBarret.transform.position;
            Debug.Log(direction);
            //direction.Normalize();
            shoot(direction, 40);
        }
    }

    public void shoot(Vector2 direction, float speed)
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.transform.position = gunBarret.transform.position;
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * speed;
            bullet.SetActive(true);
        }
    }
}
