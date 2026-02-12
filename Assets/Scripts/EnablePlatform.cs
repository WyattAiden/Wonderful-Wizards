using UnityEngine;

public class EnablePlatform : MonoBehaviour, EventInterface
{

    public UltimatePlatform linkedPlatform;
    public UltimatePlatform linkedPlatform2;
    public void OnInteract(PlayerController player)
    {
        if (linkedPlatform != null) linkedPlatform.isOn = true;
        if (linkedPlatform2 != null) linkedPlatform2.isOn = true;

    }
}
