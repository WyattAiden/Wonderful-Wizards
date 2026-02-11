using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour, EventInterface
{
    
    public void OnInteract(PlayerController player)
    {
        Physics2D.gravity *= -1f;

        PlayerController[] Players =
        Object.FindObjectsByType<PlayerController>(FindObjectsSortMode.None);

        foreach (PlayerController Player in Players) 
        {
            Player.FlipToes();
        }
        Debug.Log("Gravity Flipped");
    }

}
