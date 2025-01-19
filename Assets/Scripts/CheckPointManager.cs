using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    
    public Vector3 lastCheckPoint;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastCheckPoint = spawnPoint.position;
    }

    public void UpdateCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckPoint = checkpointPosition;
        Debug.Log("Checkpoint updated: " + checkpointPosition);
    }

    public void RespawnPlayer()
    {
        if (player != null)
        {
            player.transform.position = new Vector3(lastCheckPoint.x, lastCheckPoint.y+3, lastCheckPoint.z);
            Debug.Log("Player respawned at: " + lastCheckPoint);
        }
    }
}
