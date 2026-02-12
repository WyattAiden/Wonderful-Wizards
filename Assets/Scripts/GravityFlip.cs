using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour, EventInterface
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnInteract(PlayerController player)
    {
        Physics2D.gravity *= -1f;

        PlayerController[] Players =
        Object.FindObjectsByType<PlayerController>(FindObjectsSortMode.None);

        foreach (PlayerController Player in Players) 
        {
            Player.FlipToes();

            transform.Rotate(0f, 0f, 180f);

            player.rb2d.linearVelocityY = 0;
        }
        audioManager.PlaySFX(audioManager.GrvitySwitch);
        Debug.Log("Gravity Flipped");
    }

}
