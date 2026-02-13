using UnityEngine;
using TMPro;


public class LastRecordedTime : MonoBehaviour
{

    public TextMeshProUGUI lastTimeText;

    void Start()
    {
        float lastTime = PlayerPrefs.GetFloat("lastRecordedTime", 0f);


        if (lastTime > 0)
        {

            int minutes = Mathf.FloorToInt(lastTime / 60);
            int seconds = Mathf.FloorToInt(lastTime % 60);

            lastTimeText.text = string.Format("Last Run: {0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            lastTimeText.text = "Last Run: --:--";
        }
    }
}
