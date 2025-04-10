using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool jumpQueued = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input
        movement.x = Input.GetAxisRaw("Horizontal");

        // Detect jump key (Spacebar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump key pressed.");
            jumpQueued = true;
        }
    }

    void FixedUpdate()
    {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
        Debug.Log("isGrounded: " + isGrounded + " | jumpQueued: " + jumpQueued);

        // Move horizontally
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Jump if queued and grounded
        if (jumpQueued && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        jumpQueued = false; // clear after each FixedUpdate
    }

    // Optional: Visualize ground check circle
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, 0.3f);
        }
    }
}
