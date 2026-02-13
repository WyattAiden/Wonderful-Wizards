using Unity.VisualScripting;
using UnityEngine;

public class CameraAverage : MonoBehaviour
{
    public Transform[] playerTransforms = new Transform[3];
    public Transform YReference;
    public bool isMirror = false;

    private void Update()
    {
        if (!isMirror)
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
                    new Vector3 (playerTransforms[0].transform.position.x, YReference.position.y, - 10);
            }
            else if (i == 2)
            {
                gameObject.transform.position =
                    new Vector3((playerTransforms[0].transform.position.x + playerTransforms[1].transform.position.x) / 2,
                    YReference.position.y,//(GameMan.Players[i - 1].transform.position.y + GameMan.Players[i].transform.position.y) / 2,
                    - 10
                    );
            }
            else if (i == 3)
            {
                gameObject.transform.position =
                    new Vector3((playerTransforms[0].transform.position.x + playerTransforms[1].transform.position.x + playerTransforms[2].transform.position.x) / 3,
                    YReference.position.y,//(GameMan.Players[i - 1].transform.position.y + GameMan.Players[i].transform.position.y + GameMan.Players[i + 1].transform.position.y) / 3,
                    -10
                    );
            }
            i = 0;
        }
        else if (isMirror)
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
                    new Vector3(playerTransforms[0].transform.position.x, YReference.position.y, - 10);
            }   
            else if (i == 2)
            {
                gameObject.transform.position =
                    new Vector3((playerTransforms[0].transform.position.x + playerTransforms[1].transform.position.x) / 2,
                    YReference.position.y,
                    -10
                    );
            }
            else if (i == 3)
            {
                gameObject.transform.position =
                    new Vector3((playerTransforms[0].transform.position.x + playerTransforms[1].transform.position.x + playerTransforms[2].transform.position.x) / 3,
                    YReference.position.y,
                    -10
                    );
            }
            i = 0;
        }
        else
        {
            Debug.Log("isMirror Null");
        }
    }
}
