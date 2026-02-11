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
    private float startTime;
    private bool isRunning;
    private const string LeaderboardKey = "BestTimes";

    private List<float> bestTimes = new List<float>();

    void Start()
    {
        LoadLeaderboardData();
        StartTimer();

    }

    void Update()
    {
       if (isRunning)
        {
            float elapsed = Time.time - startTime;
            timerText.text = $"time: {elapsed:F2}s";
        }

    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }
    public void StopTimer()
    {

        isRunning = false;
        float finalTime = Time.time - startTime;
        SaveTime(finalTime);
        DisplayLeaderboard();
    }
    private void LoadLeaderboardData()
    {

        string savedData = PlayerPrefs.GetString(LeaderboardKey, "");
        if (!string.IsNullOrEmpty(savedData))
        {
            bestTimes = savedData.Split(',')
                .Select(float.Parse)
                .ToList();

        }
    }



    private void SaveTime( float time)
    {
        List<float> bestTime = PlayerPrefs.GetString(LeaderboardKey, "")
            .Split(',')
            .Where(s => float.TryParse(s, out _))
            .Select(float.Parse)
            .ToList();

        bestTimes.Add(time);
        bestTimes.Sort();
        if (bestTimes.Count > 5) bestTimes.RemoveRange(5, bestTimes.Count - 5);

        PlayerPrefs.SetString(LeaderboardKey, string.Join(",", bestTimes));
        PlayerPrefs.Save();
    }


    public void DisplayLeaderboard()
    {
        string[] times = PlayerPrefs.GetString(LeaderboardKey, "").Split(',');
        leaderboardText.text = "Top Times:/n";
        for (int i = 0; i <times.Length; i++)
        {
            leaderboardText.text += $"{i + 1}. {float.Parse(times[i]):F2}s/n";
        }
    }

}
