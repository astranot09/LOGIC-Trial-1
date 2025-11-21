using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class LeaderboardData
{
    public List<float> scores = new List<float>();
}

public class LeaderboardManager : MonoBehaviour
{
    string filePath;
    public LeaderboardData leaderboardData;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/leaderboard.json";
        LoadData();
    }

    public void AddScore(float score)
    {
        leaderboardData.scores.Add(score);

        // Sort descending (besar -> kecil)
        leaderboardData.scores.Sort((a, b) => b.CompareTo(a));

        // Keep only top 10
        if (leaderboardData.scores.Count > 10)
            leaderboardData.scores = leaderboardData.scores.GetRange(0, 10);

        SaveData();
    }

    public List<float> GetSortedScores()
    {
        List<float> sorted = new List<float>(leaderboardData.scores);
        sorted.Sort((a, b) => b.CompareTo(a)); // high to low
        return sorted;
    }

    void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            leaderboardData = JsonUtility.FromJson<LeaderboardData>(json);
        }
        else
        {
            leaderboardData = new LeaderboardData();
        }
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(leaderboardData, true);
        File.WriteAllText(filePath, json);
    }
}