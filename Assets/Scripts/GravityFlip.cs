using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour, EventInterface
{
    
    public void OnInteract()
    {
        Physics2D.gravity *= -1f;

        PlayerController[] players =
        Object.FindObjectsByType<PlayerController>(FindObjectsSortMode.None);

        foreach (PlayerController player in players) 
        {
            player.FlipToes();
        }
        Debug.Log("Gravity Flipped");
    }
}
