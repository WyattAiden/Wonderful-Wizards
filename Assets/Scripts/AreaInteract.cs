using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class AreaInteract : MonoBehaviour
{
    public bool playerInRange;
    public bool playerHitE;
    void Awake()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.isTrigger = true;
        box.size = new Vector2(3f, 3f);
    }
    public void TriggerSwitch()
    {
        if (playerInRange)
        {
            //send event to other script on this object regardless of which script it is    
        }
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!playerInRange) playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
