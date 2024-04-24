using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float gravity = -15f;
    private float jumpPower = 8f;
    private Rigidbody2D rb;
    public bool grounded;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (grounded)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity += new Vector2(0, gravity * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        if (grounded || transform.position.y < 4.5f)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    public void SetGrounded(bool value)
    {
        grounded = value;
    }
}
