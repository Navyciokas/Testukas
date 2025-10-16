using UnityEngine;
//using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private int score = 0;
    private Rigidbody2D rb;
    public float jumpForce = 5;
    public float speed = 5;
    Vector2 movementInput;
    Vector3 startPosition;

    /*public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }*/

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //jumpSound.Play();
        }
        if (Input.GetKeyDown("a"))
        {
            transform.position = new Vector3(transform.position.x - speed*10 * Time.deltaTime, transform.position.y, 0);
        }
        if (Input.GetKeyDown("d"))
        {
            transform.position = new Vector3(transform.position.x + speed*10 * Time.deltaTime, transform.position.y, 0);
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Point"))
        {

            score += 1;
        }
    }
}
