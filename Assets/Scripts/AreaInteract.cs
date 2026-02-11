using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class AreaInteract : MonoBehaviour
{
    public void TriggerSwitch(PlayerController player)
    {
        Debug.Log("Switch Triggered");
            
        EventInterface[] listeners = GetComponents<EventInterface>();
          
        foreach (EventInterface listener in listeners)   
        {
           listener.OnInteract(player);
        }   
    }
}
