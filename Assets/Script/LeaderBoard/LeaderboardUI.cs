using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject rowPrefab;
    LeaderboardManager leaderboard;

    void Start()
    {
        leaderboard = GetComponent<LeaderboardManager>();
        ShowLeaderboard();
    }

    void ShowLeaderboard()
    {
        var sortedScores = leaderboard.GetSortedScores();

        for (int i = 0; i < sortedScores.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentParent);
            LeaderboardRowPrefab rowScript = row.GetComponent<LeaderboardRowPrefab>();
            rowScript.SetRow(i + 1, sortedScores[i]);
        }
    }
}