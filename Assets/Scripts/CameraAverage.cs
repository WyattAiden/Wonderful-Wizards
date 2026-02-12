using Unity.VisualScripting;
using UnityEngine;

public class CameraAverage : MonoBehaviour
{
    public Transform[] playerTransforms = new Transform[3];

    private void Update()
    {
        if (gameObject.name == "Display1 Camera")
        {
            int i = 0;
            foreach (PlayerController player in GameMan.Players)
            {
                if (!player.isMirror)
                {
                    playerTransforms[i] = player.transform;

                    i++;
                }
            }

            if (i == 1)
            {
                gameObject.transform.position = 
                    new Vector3 (GameMan.Players[i-1].transform.position.x, GameMan.Players[i-1].transform.position.y, GameMan.Players[i - 1].transform.position.z - 10);
            }
            else if (i == 2)
            {
                gameObject.transform.position =
                    new Vector3((GameMan.Players[i - 1].transform.position.x + GameMan.Players[i].transform.position.x) / 2,
                    (GameMan.Players[i - 1].transform.position.y + GameMan.Players[i].transform.position.y) / 2,
                    -10
                    );
            }
            else if (i == 3)
            {
                gameObject.transform.position =
                    new Vector3((GameMan.Players[i - 1].transform.position.x + GameMan.Players[i].transform.position.x + GameMan.Players[i + 1].transform.position.x) / 3,
                    (GameMan.Players[i - 1].transform.position.y + GameMan.Players[i].transform.position.y + GameMan.Players[i + 1].transform.position.y) / 3,
                    -10
                    );
            }
            i = 0;
        }
        else if (gameObject.name == "Display2 Camera")
        {
            int i = 0;
            foreach (PlayerController player in GameMan.Players)
            {
                if (player.isMirror)
                {
                    playerTransforms[i] = player.transform;

                    i++;
                }
            }

            if (i == 1)
            {
                gameObject.transform.position =
                    new Vector3(GameMan.Players[i - 1].transform.position.x, GameMan.Players[i - 1].transform.position.y, GameMan.Players[i - 1].transform.position.z - 10);
            }
            else if (i == 2)
            {
                gameObject.transform.position =
                    new Vector3((GameMan.Players[i - 1].transform.position.x + GameMan.Players[i].transform.position.x) / 2,
                    (GameMan.Players[i - 1].transform.position.y + GameMan.Players[i].transform.position.y) / 2,
                    -10
                    );
            }
            else if (i == 3)
            {
                gameObject.transform.position =
                    new Vector3((GameMan.Players[i - 1].transform.position.x + GameMan.Players[i].transform.position.x + GameMan.Players[i + 1].transform.position.x) / 3,
                    (GameMan.Players[i - 1].transform.position.y + GameMan.Players[i].transform.position.y + GameMan.Players[i + 1].transform.position.y) / 3,
                    -10
                    );
            }
            i = 0;
        }
        else
        {
            Debug.Log("Display Camera Name Wrong");
        }
    }
}
