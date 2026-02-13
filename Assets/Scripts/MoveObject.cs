using UnityEngine;

public class MoveObject : MonoBehaviour, EventInterface
{
    public GameObject PairedHole;
    public bool isMirror = false;
    public ParticleSystem portalParticles;

    public void OnInteract(PlayerController player)
    {
        if (player.itemHolding == null) return;

        Pickup pickup = player.itemHolding.GetComponent<Pickup>();
        if (pickup != null)
        {
            pickup.SendThroughHole(PairedHole, player);
            portalParticles.Play();
            MoveObject Pairedhol = PairedHole.gameObject.GetComponent<MoveObject>();
            Pairedhol.portalParticles.Play();
        }
    }
}
