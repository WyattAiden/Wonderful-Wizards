using UnityEngine;

public class DissolveZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.itemHolding = null;
            {
                foreach (Transform child in player.transform)
                {
                    if (child.name != "Feet")
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }
    }
}
