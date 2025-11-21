using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInputMechanic : MonoBehaviour, IPointerClickHandler
{
    public string card;
    public GameObject confirmPanel;
    public MechanicGame mechanicGame;

    private void Start()
    {
        mechanicGame = GameObject.Find("Manager").GetComponent<MechanicGame>();
        StartCoroutine(DisableInputTemporarily());
    }
    //private void Update()
    //{
    //    if (mechanicGame.playerChoose == true && mechanicGame.enemyChoose == true)
    //    {
    //        StartCoroutine(DisableInputTemporarily());
    //        mechanicGame.playerChoose = false;
    //        mechanicGame.enemyChoose = false;
    //    }
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (mechanicGame.playerChoose == false && !PausedController.IsGamePaused)
        {
            mechanicGame.randomEnemyCard();
            mechanicGame.playerChoose = true;
            mechanicGame.inputPlayer = card;
            confirmPanel.SetActive(true);
            StartCoroutine(DisableInputTemporarily());
        }
    }
    public void DisableInputTemporarilyVoid()
    {
        StartCoroutine(DisableInputTemporarily());
    }

    private IEnumerator DisableInputTemporarily()
    {
        // Disable the script so it won't respond to clicks
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        // Re-enable after 2 seconds
        this.enabled = true;
    }
}
