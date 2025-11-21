using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    public Image healthBar;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public Image icon;
    public EnemyScript enemyScript;

    private void Start()
    {
        enemyScript = GetComponent<EnemyScript>();

        healthBar = GameObject.Find("EnemyHealthBar").GetComponent<Image>();
        if (healthBar == null)
            Debug.LogError("HealthBar not found in child objects");

        nameText = GameObject.Find("EnemyName").GetComponent<TMP_Text>();
        if (nameText == null)
            Debug.LogError("HealthBar not found in child objects");

        healthText = GameObject.Find("EnemyHealthText").GetComponent<TMP_Text>();
        if (healthText == null)
            Debug.LogError("HealthBar not found in child objects");

        icon = GameObject.Find("EnemyIcon").GetComponent<Image>();
        if (icon == null)
            Debug.LogError("EnemyIcon not found in child objects");

        UpdateUI();

    }
    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        nameText.text = enemyScript.enemyData.entityName;
        healthText.text = $"{enemyScript.health}/{enemyScript.maxHealth}";
        icon.sprite = enemyScript.enemyData.entityIcon;
        healthBar.fillAmount = enemyScript.health / enemyScript.maxHealth;
    }
}
