using UnityEngine;

public class BulletMomevent : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float speed = 2;
    public Vector2 bulletDirection {  get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.linearVelocity = bulletDirection.normalized * speed;        
    }
}
