using UnityEngine;

public class PlayerTestMovement : MonoBehaviour
{

    public PlayerTestController controller;

    private float horizontalMove = 0f;

    [SerializeField] private float walkSpeed = 10f;
    [SerializeField] private float runSpeed = 40f;

    private bool jump = false;
    private bool isRunning = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        if (isRunning)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            Debug.Log("Jumping");

        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, jump);
        jump = false;
    }
}
