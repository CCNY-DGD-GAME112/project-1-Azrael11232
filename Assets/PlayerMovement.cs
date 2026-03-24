using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float floats = 0.5f;

    private Rigidbody2D rb;
    private bool onGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0f, transform.rotation.w);

        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        // Constant movement to the right


        // Jump only if grounded
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            onGround = false; // immediately prevent double jump
        }

        // Variable jump height: if space is held and player is moving upwards, apply additional force
        if (Input.GetKey(KeyCode.Space) && rb.linearVelocity.y > 0)
        {
            if (rb.linearVelocity.y < jumpForce + floats)
            {
                rb.linearVelocity += new Vector2(0f, floats * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            onGround = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.PlayerDied();
            Destroy(gameObject);
        }
    }
}
