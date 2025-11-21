using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public float scoreCount;
    public float enemyDefeatedCount;
    public float playCount;

    public void Start()
    {
        scoreText = GameObject.Find("ScoreCount").GetComponent<TMP_Text>();
        if (scoreText == null)
            Debug.LogError("scoreText not found in child objects");
        scoreCount = 0;
        scoreText.text = scoreCount.ToString();
    }

    public void UpdateScore(int plusScore)
    {
        scoreCount += plusScore;
        scoreText.text = scoreCount.ToString();
        GameManager.instance.spawnEnemy();
    }
}
