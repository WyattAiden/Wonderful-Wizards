using UnityEngine;

public class EnablePlatform : MonoBehaviour, EventInterface
{

    public UltimatePlatform linkedPlatform;
    public UltimatePlatform linkedPlatform2;
    public bool enablesMovement = false;
    public bool enablesPlatform = false;
    public void OnInteract(PlayerController player)
    {
        if (enablesPlatform)
        {
            if (linkedPlatform != null) linkedPlatform.isOn = true;
            if (linkedPlatform2 != null) linkedPlatform2.isOn = true;
        }
        if (enablesMovement)
        {
            if (linkedPlatform != null) linkedPlatform.isMovingPlatform = true;
            if (linkedPlatform2 != null) linkedPlatform2.isMovingPlatform = true;
        }
    }
}
