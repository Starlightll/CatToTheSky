using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTestController : MonoBehaviour
{


    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private Transform player;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] bool airControl = false;
    [SerializeField] private float jumpForce = 400f;
    [Range(0, .3f)][SerializeField] private float movementSmoothing = .05f;

    public bool isGrounded = false;
    private bool wasGrounded = false;
    private bool m_FacingRight = true;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    public Rigidbody2D Rigidbody2D { get => rigidbody2D; set => rigidbody2D = value; }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Comma))
        {
            if (gameObject.IsDestroyed())
            {
                gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        //Debug.Log(isGrounded);
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if(!wasGrounded)
                {
                    Debug.Log("OnLandEvent Invoke");
                    OnLandEvent.Invoke();
                }
                //Debug.Log("Grounded");
            }
        }
    }

    public void Move(float moveSpeed, bool jump)
    {
        if(isGrounded || airControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(moveSpeed * 10f, rigidbody2D.linearVelocity.y);
            rigidbody2D.linearVelocity = Vector3.SmoothDamp(rigidbody2D.linearVelocity, targetVelocity, ref velocity, movementSmoothing);

            if (moveSpeed > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (moveSpeed < 0 && m_FacingRight)
            {
                Flip();
            }
        }

        if (jump)
        {
            if (isGrounded)
            {
                rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, 0); // Reset y velocity
                rigidbody2D.AddForce(new Vector2(0f, jumpForce)); // Add jump 
                isGrounded = false; // Reset grounded
                //Debug.Log("On Jumping");
            }
        }

    }



    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}
