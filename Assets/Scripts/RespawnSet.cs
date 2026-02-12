using UnityEngine;

public class RespawnSet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pController = collision.GetComponent<PlayerController>();

            pController.respawnPOS = transform.parent.gameObject;
        }
    }
}
