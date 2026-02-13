using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    public float floatStrength = 0.5f;
    private Rigidbody2D rb;
    private ItemPickup heldItem;
    private bool isFloating = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if we are holding an item
        if (heldItem == null)
        {
            heldItem = GetComponentInChildren<ItemPickup>();
        }

        // Handle the Toggle logic
        if (heldItem != null && heldItem.isHeld)
        {
            // GetKeyDown only triggers ONCE per press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isFloating = !isFloating; // Flip the true/false state
            }
        }
        else
        {
            // If item is dropped or not held, force float to OFF
            isFloating = false;
        }

        // Apply the physics based on the toggle state
        ApplyFloatPhysics();
    }

    void ApplyFloatPhysics()
    {
        if (isFloating)
        {
            rb.gravityScale = -floatStrength; // Drifting up
        }
        else
        {
            rb.gravityScale = 1f; // Normal weight
        }
    }
}