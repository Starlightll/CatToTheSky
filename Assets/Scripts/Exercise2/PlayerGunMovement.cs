using UnityEngine;

public class PlayerGunMovement : MonoBehaviour
{
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaySceneController.isPaused) return;
        RotateGunTowardsMouse();
    }

    void RotateGunTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        
        if(direction.y < 0) {
            direction.y = 0;
        }
        transform.up = direction;




        //Debug.Log(direction);

    }
}
