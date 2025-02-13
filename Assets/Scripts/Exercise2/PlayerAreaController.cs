using UnityEngine;

public class PlayerAreaController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("PlayerBullet"))
        //{
        //    Destroy(collision.gameObject);
        //}
    }
}
