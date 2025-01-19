using UnityEngine;

public class RespawnManagerTest : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab; // Prefab của Player
    [SerializeField] private Transform spawnPoint; // Vị trí hồi sinh Player
    [SerializeField] private GameObject currentPlayer;                // Tham chiếu tới Player hiện tại

    void Update()
    {
        // Kiểm tra nếu người dùng nhấn phím R
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }
    }

    // Hồi sinh Player
    private void RespawnPlayer()
    {
        // Nếu Player hiện tại đã bị vô hiệu hóa hoặc null
        if (currentPlayer == null || !currentPlayer.activeSelf)
        {
            // Xóa Player cũ nếu tồn tại
            if (currentPlayer != null)
            {
                Destroy(currentPlayer);
            }

            // Tạo một Player mới tại vị trí spawn
            currentPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);

            Debug.Log("Player đã được hồi sinh!");
        }
        else
        {
            Debug.Log("Player vẫn đang hoạt động!");
        }
    }
}
