using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class AreaInteract : MonoBehaviour
{
    public bool playerInRange = false;
    public bool playerHitE;
    public void TriggerSwitch()
    {
        Debug.Log("Switch Triggered");
            
        EventInterface[] listeners = GetComponents<EventInterface>();
          
        foreach (EventInterface listener in listeners)   
        {
           listener.OnInteract();
        }   
    }
}
