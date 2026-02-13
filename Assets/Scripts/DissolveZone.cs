using UnityEngine;

public class DissolveZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.itemHolding = null;
            {
                foreach (Transform child in player.transform)
                {
                    if (child.name == "GravBall")
                    {
                        Destroy(child.gameObject);
                        if (player.isMirror)
                        {
                            foreach (PlayerController playah in GameMan.Players)
                            {
                                if (playah.isMirror)
                                {
                                    playah.FlipIndividualGravity();
                                }
                            }
                        }
                        else if (!player.isMirror)
                        {
                            foreach (PlayerController playah in GameMan.Players)
                            {
                                if (!playah.isMirror)
                                {
                                    playah.FlipIndividualGravity();
                                }
                            }
                        }
                    }
                    else if (child.name != "Feet")
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }
    }
}
