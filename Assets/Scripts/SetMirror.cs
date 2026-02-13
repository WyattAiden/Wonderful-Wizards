using Unity.VisualScripting;
using UnityEngine;

public class SetMirror : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.isMirror = true;
        }
    }
}
