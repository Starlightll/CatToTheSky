using UnityEngine;

public class RespawnManagerTest : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject currentPlayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        if (currentPlayer == null || !currentPlayer.activeSelf)
        {
            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }

            currentPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
            
        }
        else
        {
            
        }
    }
}
