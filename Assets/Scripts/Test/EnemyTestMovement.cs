using System;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EnemyTestMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidbody2D;
    [Range(0, 400f)][SerializeField] private float moveSpeed = 20f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float rayLength = 0.55f;
    [SerializeField] private Animator animator;

    private EnemySpawnerTest enemySpawner;




    private enum Direction
    {
        Left,
        Right
    }

    private Direction direction = Direction.Left;
    private Rigidbody2D rb;

    public void SetMoveSpped(float speed)
    {
        this.moveSpeed = speed;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySpawner = FindFirstObjectByType<EnemySpawnerTest>();
    }

    private void Update()
    {

        //bool hitWallLeft = Physics2D.Raycast(transform.position, Vector2.left, rayLength, groundLayer);
        //bool hitWallRight = Physics2D.Raycast(transform.position, Vector2.right, rayLength, groundLayer);


        //if (hitWallLeft)
        //{
        //    Debug.Log("HitWall");
        //    direction = Direction.Right;
        //}
        //else if (hitWallRight)
        //{
        //    Debug.Log("HitWallRight");
        //    direction = Direction.Left;
        //}
        Vector3 theScale = transform.localScale;
        if (direction == Direction.Left)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
            theScale.x = theScale.x > 0 ? theScale.x * -1 : theScale.x;
        }
        else
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
            theScale.x = theScale.x < 0 ? theScale.x * -1 : theScale.x;
        }
        transform.localScale = theScale;

        if (moveSpeed > 5)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsWalking", true);
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

        foreach (ContactPoint2D hitPos in collision.contacts)
        {
            if (hitPos.normal.y < 0)
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    gameObject.SetActive(false);
                    enemySpawner.enemyPool.Enqueue(gameObject);
                    break;
                }
            }
            else
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    collision.gameObject.SetActive(false);
                    break;
                }
            }
        }

    }

    public void ChangeDirection(string directionInput)
    {
        if(directionInput.ToLower().Equals("left"))
        {
            direction = Direction.Left;
        }
        else if (directionInput.ToLower().Equals("right"))
        {
            direction = Direction.Right;
        }
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

        //private void OnCollisionStay2D(Collision2D collision)
        //{
        //    foreach (ContactPoint2D hitPos in collision.contacts)
        //    {
        //        //Debug.Log(hitPos.normal.x);
        //        //Debug.Log(hitPos.normal.y);
        //        if (hitPos.normal.x != 0 && (collision.gameObject.CompareTag("Ground")))
        //        {
        //            Debug.Log("HitWall");
        //            //if (hitPos.normal.x > 0)
        //            //{
        //            //    Debug.Log("Right");
        //            //    direction = Direction.Right;
        //            //}
        //            //else
        //            //{
        //            //    Debug.Log("Left");
        //            //    direction = Direction.Left;
        //            //}
        //        }
        //    }
        //}
    }
