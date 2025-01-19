using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private CheckPointManager checkPointManager;


    private void Start()
    {
        checkPointManager = FindFirstObjectByType<CheckPointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(gameObject.transform.position != checkPointManager.lastCheckPoint)
            {
                checkPointManager.UpdateCheckpoint(transform.position);
            }
        }
    }

}
