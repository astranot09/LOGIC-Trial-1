using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Image healthBar;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public Image icon;
    public PlayerScript playerScript;

    private void Start()
    {
        playerScript = GetComponent<PlayerScript>();

        healthBar = GameObject.Find("PlayerHealthBar").GetComponent<Image>();
        if (healthBar == null)
            Debug.LogError("HealthBar not found in child objects");

        nameText = GameObject.Find("PlayerName").GetComponent<TMP_Text>();
        if (nameText == null)
            Debug.LogError("HealthBar not found in child objects");

        healthText = GameObject.Find("PlayerHealthText").GetComponent<TMP_Text>();
        if (healthText == null)
            Debug.LogError("HealthBar not found in child objects");

        icon = GameObject.Find("PlayerIcon").GetComponent<Image>();
        if (icon == null)
            Debug.LogError("EnemyIcon not found in child objects");

        UpdateUI();
    }

    public void UpdateUI()
    {
        nameText.text = playerScript.playerData.entityName;
        healthText.text = $"{playerScript.health}/{playerScript.maxHealth}";
        icon.sprite = playerScript.playerData.entityIcon;
        healthBar.fillAmount = playerScript.health / playerScript.maxHealth;
    }
}
