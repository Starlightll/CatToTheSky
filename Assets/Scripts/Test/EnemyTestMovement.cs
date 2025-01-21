using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EnemyTestMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidbody2D;
    [Range(0, 400f)][SerializeField] private float moveSpeed = 20f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 0.55f;

    private EnemySpawnerTest enemySpawner;


    private enum Direction
    {
        Left,
        Right
    }

    private Direction direction = Direction.Left;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySpawner = FindFirstObjectByType<EnemySpawnerTest>();
    }

    private void Update()
    {
        
        bool hitLeft = Physics2D.Raycast(transform.position, Vector2.left, rayLength, groundLayer);
        bool hitRight = Physics2D.Raycast(transform.position, Vector2.right, rayLength, groundLayer);

        if (hitLeft)
        {
            direction = Direction.Right; 
        }
        else if (hitRight)
        {
            direction = Direction.Left;
        }

        if(direction == Direction.Left)
        {
            rb.linearVelocity = new Vector2(-moveSpeed * Time.deltaTime, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(moveSpeed * Time.deltaTime, rb.linearVelocity.y);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLength);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y < 0)
                {
                    Debug.Log("Player is on top of the enemy");
                    gameObject.SetActive(false);
                    enemySpawner.enemyPool.Enqueue(gameObject);
                    return;
                }
                else
                {
                    Debug.Log("Player is on the side of the enemy");
                    collision.gameObject.SetActive(false);
                    return;
                }
            }
        }
    }
}
