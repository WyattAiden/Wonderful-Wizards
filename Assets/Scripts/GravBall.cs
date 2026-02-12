using UnityEngine;

public class GravBall : MonoBehaviour
{
    private Rigidbody2D rb2d;
    AudioManager audioManager;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void flipSideGravity(PlayerController playah)
    {
        if (playah.isMirror)
        {
            foreach (PlayerController player in GameMan.Players)
            {
                if (player.isMirror) player.FlipIndividualGravity();
            }
            rb2d.gravityScale *= -1f;
            rb2d.linearVelocityY = 0;
        }
        else
        {
            foreach (PlayerController player in GameMan.Players)
            {
                if (!player.isMirror) player.FlipIndividualGravity();
            }
            rb2d.gravityScale *= -1f;
            rb2d.linearVelocityY = 0;
        }
        audioManager.PlaySFX(audioManager.GrvitySwitch);
    }
}
