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
        if(target == null || target.activeSelf == false)
        {
            target = null;
            FindTarget();
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = startDirection;
        timer += Time.deltaTime;
        if (target != null)
        {
            Vector2 targetPosition = target.transform.position;
            //Debug.Log(timer);

            if (isHoming && timer > 0.1f)
            {
                //direction = (Vector2)target.transform.position - rb.position;
                targetPosition = PredictFuturePosition();
                direction = targetPosition - rb.position;
            }
            
        }

        direction.Normalize();

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        float currentAngle = rb.rotation;

        float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * timer * Time.fixedDeltaTime / 100f);

        rb.rotation = newAngle;

        //float rotateAmount = Vector3.Cross(direction, transform.up).z;
        //rb.angularVelocity = -rotateAmount * rotationSpeed;

        //Predict the future position of the target
        

        rb.linearVelocity = transform.up * homingSpeed * (timer/1.5f);

    }

    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemySpawner.KillEnemy(collision.gameObject);
            Destroy(gameObject);
        }

    }

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
