using UnityEngine;

public class testcontroler : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        // Automatically get the Rigidbody2D component on the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from A/D or Left/Right arrow keys
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Optional: Flip the sprite based on direction
        FlipSprite();
    }

    void FixedUpdate()
    {
        // Apply velocity for physics-based movement
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1); // Face right
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Face left
    }
}
