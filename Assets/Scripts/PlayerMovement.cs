using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public PlayerController controller;
    public Animator animator;

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

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("IsRunning", isRunning);
        animator.SetFloat("yVelocity", controller.m_Rigidbody2D.linearVelocity.y);
        animator.SetFloat("IdleTime", controller.m_idleTime);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (!controller.m_Grounded)
        {
            animator.SetBool("IsJumping", true);
        }
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove, false, jump);
        jump = false;
    }
}
