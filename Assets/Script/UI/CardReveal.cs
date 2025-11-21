using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardReveal : MonoBehaviour
{
    public Image iconPlayerCardReveal;
    public Image iconEnemyCardReveal;

    public Sprite rockIcon;
    public Sprite paperIcon;
    public Sprite scissorIcon;

    public MechanicGame mechanicGame;

    void Start()
    {
        mechanicGame = GetComponent<MechanicGame>();
        iconEnemyCardReveal.enabled = false;
        iconPlayerCardReveal.enabled = false;
    }

    public void cardReveal()
    {
        if (mechanicGame == null)
        {
            Debug.LogError("MechanicGame reference is missing!");
            return;
        }

        iconEnemyCardReveal.sprite = GetCardSprite(mechanicGame.inputEnemy) ?? rockIcon;
        iconPlayerCardReveal.sprite = GetCardSprite(mechanicGame.inputPlayer) ?? rockIcon;

        iconEnemyCardReveal.enabled = true;
        iconPlayerCardReveal.enabled = true;

        StartCoroutine(ClearIcons());
    }

    private Sprite GetCardSprite(string card)
    {
        switch (card) // Normalize input for safety
        {
            case "rock": return rockIcon;
            case "paper": return paperIcon;
            case "scissor": return scissorIcon;
            default:
                Debug.LogWarning($"Invalid card type: {card}. Using default sprite.");
                return null;
        }
    }
    public IEnumerator ClearIcons()
    {
        yield return new WaitForSeconds(2f); // Tunggu 2 detik

        iconEnemyCardReveal.sprite = null;
        iconPlayerCardReveal.sprite = null;

        iconEnemyCardReveal.enabled = false;
        iconPlayerCardReveal.enabled = false;

        mechanicGame.playerChoose = false;
        mechanicGame.enemyChoose = false;
    }
}
