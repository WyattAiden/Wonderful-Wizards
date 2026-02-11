using UnityEngine;

public class Antigravity : MonoBehaviour
{
    public Rigidbody rb;
    public float floatForce = 12f; // Adjust to find the "slow" sweet spot
    public bool isFloating = false;

    void Update()
    {
        // Toggle the state when Space is pressed once
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFloating = !isFloating;

            // Optional: Reset vertical velocity so the float starts "clean"
            if (isFloating) rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        }
    }

    void FixedUpdate()
    {
        if (isFloating)
        {
            // Apply upward force continuously while toggled on
            rb.AddForce(Vector3.up * floatForce);
        }
    }

}
