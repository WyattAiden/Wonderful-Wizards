using UnityEngine;

public class MoveObject : MonoBehaviour, EventInterface
{
    public GameObject PairedHole;

    public void OnInteract(PlayerController player)
    {
        if (player.itemHolding == null) return;

        Pickup pickup = player.itemHolding.GetComponent<Pickup>();
        if (pickup != null) pickup.SendThroughHole(PairedHole, player);
    }
}
