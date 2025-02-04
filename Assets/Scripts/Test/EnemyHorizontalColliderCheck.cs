using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyHorizontalColliderCheck : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    private EnemyTestMovement enemyMovement;

    private Direction direction;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(enemy == null)
        {
            enemy = GameObject.Find("Enemy");
        }
        enemyMovement = enemy.GetComponent<EnemyTestMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision");
        foreach (ContactPoint2D hitPos in collision.contacts)
        {
           //Debug.Log(hitPos.normal.x);
           if(hitPos.normal.x > 0)
            {
                enemyMovement.ChangeDirection("right");
            }
            else if (hitPos.normal.x < 0)
            {
                enemyMovement.ChangeDirection("left");
            }
        }
    }

   
}
