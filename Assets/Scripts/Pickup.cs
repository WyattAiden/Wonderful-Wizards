using UnityEngine;

public class Pickup : MonoBehaviour, EventInterface
{
    public void OnInteract()
    {
        Debug.Log("Pickup Ball");
    }
}
