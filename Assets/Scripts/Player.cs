using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 5;
    public float speed = 5f;
    public Sprite standingSprite;
    public Sprite runningSprite;

    Vector3 startPosition;
    private SpriteRenderer sr;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded = true;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        if (Input.GetKeyDown("w") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.Instance.PlayJump();
        }

        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0)
        {
            sr.flipX = false;
        }
        else if (moveInput < 0)
        {
            sr.flipX = true;
        }

        if (moveInput != 0)
        {
            sr.sprite = runningSprite;
            AudioManager.Instance.StartRunning();
        }
        else
        {
            sr.sprite = standingSprite;
            AudioManager.Instance.StopRunning();
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    public void Respawn()
    {
        transform.position = startPosition;
        rb.velocity = Vector2.zero;
        AudioManager.Instance.PlayDeath();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)  
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }*/
}