using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public UltimatePlatform linkedPlatform;
    [SerializeField, Tooltip("2nd platform only necessary for 1 puzzle")]
    public UltimatePlatform linkedPlatform2;
    public bool flipsGravity;
    private bool playerOnPad;
    public float activationTimer = 0;
    private PlayerController playerController;
    private bool hasTriggered = false;
    public float activationTimerMax = 0.5f;
    private void Update()
    {
        if (playerOnPad)
        {
            activationTimer += Time.deltaTime;
        }

        if (activationTimer >= activationTimerMax && !hasTriggered)
        {
            if (linkedPlatform != null)
            {
                linkedPlatform.isOn = true;
            }

            if (linkedPlatform2 != null)
            {
                linkedPlatform2.isOn = true;
            }

            if (flipsGravity)
            {
                EventInterface[] listeners = GetComponents<EventInterface>();

                foreach (EventInterface listener in listeners)
                {
                    if (playerController == null) return;
                    
                    listener.OnInteract(playerController);
                    
                }
            }

            hasTriggered = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController = collision.gameObject.GetComponent<PlayerController>();
            playerOnPad = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController = null;
            playerOnPad = false;
        }
    }
}
