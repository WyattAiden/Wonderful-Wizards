using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool canPickUp = false;
    private Transform playerHoldPoint;

    void Update()
    {
        // Check if player is in range and presses the 'E' key
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }
    }

    public bool isHeld = false; // Add this variable

    void PickUp()
    {
        isHeld = true; // Set to true when picked up
        transform.SetParent(playerHoldPoint);
        transform.localPosition = Vector3.zero;
        if (TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)) rb.simulated = false;
        if (TryGetComponent<Collider2D>(out Collider2D col)) col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
            // Find the HoldPoint child on the player
            playerHoldPoint = other.transform.Find("HoldPoint");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }

}