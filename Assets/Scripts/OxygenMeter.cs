using UnityEngine;
using UnityEngine.UI;

public class OxygenMeter : MonoBehaviour
{
    public Image oxygenMeter;

    public int oxygenMeterMaxPercent;

    private int oxygenMeterCurrentPercent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oxygenMeterCurrentPercent = oxygenMeterMaxPercent;
        oxygenMeter.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            MeterIncrease(10);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MeterDecrease(3);
        }
    }

    public void MeterDecrease(int i)
    {
        oxygenMeterCurrentPercent -= i;

        if (oxygenMeterCurrentPercent < 0)
        {
            oxygenMeterCurrentPercent = 0;
        }

        oxygenMeter.fillAmount = (float)oxygenMeterCurrentPercent / oxygenMeterMaxPercent;
    }

    public void MeterIncrease(int i)
    {
        oxygenMeterCurrentPercent += i;

        if (oxygenMeterCurrentPercent < 0)
        {
            oxygenMeterCurrentPercent = 0;
        }

        oxygenMeter.fillAmount = (float)oxygenMeterCurrentPercent / oxygenMeterMaxPercent;
    }
}
