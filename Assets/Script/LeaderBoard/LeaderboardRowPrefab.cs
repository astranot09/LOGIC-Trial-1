using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardRowPrefab : MonoBehaviour
{
    public TMP_Text number;
    public TMP_Text score;

    public void SetRow(float number, float score)
    {
        this.number.text = number.ToString();
        this.score.text = score.ToString();
    }
}
