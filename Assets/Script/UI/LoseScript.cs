using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LoseScript : MonoBehaviour
{
    public TMP_Text enemyKilledCount;
    public TMP_Text scoreCount;
    public TMP_Text actionCount;

    public ScoreUI scoreUI;
    public LeaderboardManager leaderboardManager;

    public static LoseScript instance;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        leaderboardManager = GameObject.Find("LeaderBoardManager")?.GetComponent<LeaderboardManager>();
        scoreUI = GetComponent<ScoreUI>();
    }
    public void loseUpdate()
    {
        enemyKilledCount.text = scoreUI.enemyDefeatedCount.ToString();
        scoreCount.text = scoreUI.scoreCount.ToString();
        actionCount.text = scoreUI.playCount.ToString();

        leaderboardManager.AddScore(scoreUI.scoreCount);

        scoreUI.enemyDefeatedCount = 0;
        scoreUI.scoreCount= 0;
        scoreUI.playCount=0;
    }
}
