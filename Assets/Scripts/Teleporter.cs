using UnityEngine;

public class Teleporter : MonoBehaviour, EventInterface
{
    public Transform destination;
    private float portalTimer = 0;
    private bool timeToPort = false;
    public float teleportDuration = 1f;
    public float playerSpacing = 1.5f;
    private PlayerController playerr;
    public bool isYSetter = false;
    public CameraAverage cam1;
    public CameraAverage cam2;

    private void Awake()
    {
    }

    public void OnInteract(PlayerController playah)
    {
        playerr = playah;
        timeToPort = true;
    }

    private void Update()
    {
        if (timeToPort) portalTimer += Time.deltaTime;
        if (portalTimer >= teleportDuration)
        {
            if (playerr.isMirror)
            {
                foreach (PlayerController player in GameMan.Players)
                {
                    if (player.isMirror)
                    {
                        int i = 1;

                        player.gameObject.transform.position = new Vector3
                            (
                            (i * destination.position.x) - destination.position.x, destination.position.y, destination.position.z
                            );
                        i++;
                    }
                }
                if (isYSetter && cam2 != null)
                {
                    cam2.YReference = destination;
                }

            }
            else
            {
                foreach (PlayerController player in GameMan.Players)
                {
                    if (!player.isMirror)
                    {
                        int i = 1;

                        player.gameObject.transform.position = new Vector3
                            (
                            destination.position.x + ((i * playerSpacing) - playerSpacing), destination.position.y, destination.position.z
                            );
                        i++;
                    }
                }
                if (isYSetter && cam1 != null)
                {
                    cam1.YReference = destination;
                }
            }
            timeToPort = false;
            portalTimer = 0;
        }

    }
    
}
