using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI leaderboardText;
    private float elapsedTime;
    private bool isRunning;
    private const string LeaderboardKey = "BestTimes";

    public Image oxygenMeter;
    public float oxygenMeterMaxPercent = 100f; // Set a default
    private float oxygenMeterCurrentPercent;

    public CanvasGroup deathScreen;
    public bool isDeathScreenVisible;

    private List<float> bestTimes = new List<float>();

    void Start()
    {
        // Initialize Oxygen
        oxygenMeterCurrentPercent = oxygenMeterMaxPercent;

        LoadLeaderboardData();
        DisplayLeaderboard(); // Show the board at the start
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Fix: Changed 'elapsed' to 'elapsedTime'
            // Also: This logic currently drains the bar extremely slowly
            if (elapsedTime > 0)
            {
                oxygenMeter.fillAmount -= 0.01f / 3 * Time.deltaTime;

                if (isDeathScreenVisible)
                {
                    deathScreen.alpha = 1;
                }
                else
                {
                    deathScreen.alpha = 0;
                }

                if (Input.GetKey(KeyCode.Escape))
                {
                    oxygenMeter.fillAmount = 1;
                    elapsedTime = 0;
                }

                if (oxygenMeter.fillAmount <= 0)
                {
                    isDeathScreenVisible = true;
                }
                else
                {
                    isDeathScreenVisible = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        elapsedTime = 0f;
        isRunning = true;
    }

    public void StopTimer()
    {
        if (!isRunning) return;

        isRunning = false;

        // Fix: Added the call to SaveTime so the leaderboard updates!
        SaveTime(elapsedTime);

        PlayerPrefs.SetFloat("lastRecordedTime", elapsedTime);
        PlayerPrefs.Save();
    }

    private void LoadLeaderboardData()
    {
        string savedData = PlayerPrefs.GetString(LeaderboardKey, "");
        if (!string.IsNullOrEmpty(savedData))
        {
            bestTimes = savedData.Split(',')
                .Where(s => !string.IsNullOrEmpty(s)) // Safety check
                .Select(float.Parse)
                .ToList();
        }
    }

    private void SaveTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort();

        if (bestTimes.Count > 5) bestTimes.RemoveRange(5, bestTimes.Count - 5);

        PlayerPrefs.SetString(LeaderboardKey, string.Join(",", bestTimes));
        PlayerPrefs.Save();

        DisplayLeaderboard();
    }

    public void DisplayLeaderboard()
    {
        if (leaderboardText == null) return;

        leaderboardText.text = "Best Times:\n";
        for (int i = 0; i < bestTimes.Count; i++)
        {
            int minutes = Mathf.FloorToInt(bestTimes[i] / 60);
            int seconds = Mathf.FloorToInt(bestTimes[i] % 60);
            leaderboardText.text += string.Format("{0}. {1:00}:{2:00}\n", i + 1, minutes, seconds);
        }
    }

    public void MeterDecrease(int i)
    {
        oxygenMeterCurrentPercent -= i;
        if (oxygenMeterCurrentPercent < 0) oxygenMeterCurrentPercent = 0;
        UpdateOxygenUI();
    }

    public void MeterIncrease(int i)
    {
        oxygenMeterCurrentPercent += i;
        if (oxygenMeterCurrentPercent > oxygenMeterMaxPercent) oxygenMeterCurrentPercent = oxygenMeterMaxPercent;
        UpdateOxygenUI();
    }

    private void UpdateOxygenUI()
    {
        oxygenMeter.fillAmount = oxygenMeterCurrentPercent / oxygenMeterMaxPercent;
    }
}
