using Unity.VisualScripting;
using UnityEngine;

public class CameraAverage : MonoBehaviour
{
    public bool isMirror;
    public Transform[] playerTransforms = new Transform[3];

    private void Update()
    {
        if (gameObject.name == "Display1 Camera")
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
                    GameMan.Players[i-1].transform.position;
            }
            if (i == 2)
            {
                gameObject.transform.position = 
                    (GameMan.Players[i - 1].transform.position + GameMan.Players[i].transform.position)/2;
            }
            if (i == 3)
            {
                gameObject.transform.position =
                    (GameMan.Players[i - 1].transform.position + GameMan.Players[i].transform.position + GameMan.Players[i + 1].transform.position) /3;
            }
            i = 0;
        }
        else if (gameObject.name == "Display2 Camera")
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
                    GameMan.Players[i - 1].transform.position;
            }
            if (i == 2)
            {
                gameObject.transform.position =
                    (GameMan.Players[i - 1].transform.position + GameMan.Players[i].transform.position) / 2;
            }
            if (i == 3)
            {
                gameObject.transform.position =
                    (GameMan.Players[i - 1].transform.position + GameMan.Players[i].transform.position + GameMan.Players[i + 1].transform.position) / 3;
            }
            i = 0;
        }
        else
        {
            Debug.Log("Display Camera Name Wrong");
        }
    }
}
