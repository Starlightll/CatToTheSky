using System.Linq;
using TMPro;
using UnityEngine;

public class MissileMovement : MonoBehaviour
{

    public float homingSpeed = 5f;
    public float rotationSpeed = 200f;
    public bool isHoming = false;
    public Vector2 startDirection;
    public GameObject target;

    private float timer = 0f;
    private Rigidbody2D rb;
    private EnemySpawner enemySpawner;
    private HomingMissileController homingMissileController;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        homingMissileController = FindFirstObjectByType<HomingMissileController>();
        enemySpawner = FindFirstObjectByType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaySceneController.isPaused) return;
        if (target == null || target.activeSelf == false)
        {
            target = null;
            FindTarget();
        }
    }

    void FixedUpdate()
    {
        // Default direction is the starting direction
        Vector2 direction = startDirection.normalized;
        timer += Time.deltaTime;

        // If we have a target and are homing, calculate the direction to it
        if (target != null && isHoming)
        {
            Vector2 targetPosition = PredictFuturePosition();
            direction = (targetPosition - rb.position).normalized;
        }

        // Calculate target angle in degrees (0 degrees points right, positive is counter-clockwise)
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Calculate maximum angular change this frame based on rotationSpeed
        float maxRotation = rotationSpeed * Time.fixedDeltaTime;

        // Find the shortest angle difference (may be negative)
        float angleDifference = Mathf.DeltaAngle(rb.rotation, targetAngle);

        // Limit rotation to maxRotation degrees per frame (for smooth turning)
        float rotationThisFrame = Mathf.Clamp(angleDifference, -maxRotation, maxRotation);

        // Apply the clamped rotation
        rb.rotation += rotationThisFrame;

        // Move forward in the direction we're facing
        rb.linearVelocity = transform.up * homingSpeed;

    }

    


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        enemySpawner.KillEnemy(collision.gameObject);
    //        Destroy(gameObject);
    //    }

    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerArea"))
        {
            Destroy(gameObject);
        }
    }

    public void StartHoming()
    {
        isHoming = true;
    }

    public void StopHoming()
    {
        isHoming = false;
    }


    private void FindTarget()
    {
        if (target == null)
        {
            //var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //if (enemies.Length > 0)
            //{
            //    target = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).First();
            //    if (target != null) Debug.Log("Target found");
            //}
            homingMissileController.ReTargetRemainMissile();
        }
    }


    private Vector2 PredictFuturePosition()
    {
        if (target == null) return target.transform.position;

        Rigidbody2D enemyRb = target.GetComponent<Rigidbody2D>();
        if (enemyRb == null) return target.transform.position;

        float distance = Vector2.Distance(rb.position, target.transform.position);
        float timeToImpact = distance / homingSpeed;
        Vector2 predictedPosition = (Vector2)target.transform.position + (enemyRb.linearVelocity * timeToImpact);

        return predictedPosition;
    }
}
