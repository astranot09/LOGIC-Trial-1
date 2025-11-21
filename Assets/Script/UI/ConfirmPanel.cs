using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmPanel : MonoBehaviour
{
    public Button confirmButton;
    public Button cancelButton;
    public MechanicGame mechanicGame;
    
    public GameObject confirmPanel;

    private void Start()
    {
        mechanicGame = GameObject.Find("Manager").GetComponent<MechanicGame>();
        
        confirmButton.onClick.AddListener(OnConfirmClick);
        cancelButton.onClick.AddListener(OnCancelClick);
    }
    public void OnConfirmClick()
    {
        mechanicGame.Check();
        confirmPanel.SetActive(false);        
    }
    public void OnCancelClick()
    {
        mechanicGame.playerChoose = false;
        confirmPanel.SetActive(false);
    }
}
