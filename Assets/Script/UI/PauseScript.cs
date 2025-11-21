using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingPanel;

    private void Update()
    {
        if(pausePanel != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pausePanel.activeSelf && PausedController.IsGamePaused)
                    return;
                pausePanel.SetActive(!pausePanel.activeSelf);
                PausedController.SetPause(pausePanel.activeSelf);
            }
        }

    }



    public void closePausePanel()
    {
            pausePanel.SetActive(!pausePanel.activeSelf);
            PausedController.SetPause(pausePanel.activeSelf);
    }
    public void closeSettingPanel()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
        PausedController.SetPause(settingPanel.activeSelf);
    }
}
