using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public GameObject scoreBoardPanel;
    void Awake()
    {
            instance = this;
    }

    public void Play()
    {
        SceneController.instance.LoadScene("SampleScene");
    }
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneController.instance.LoadScene(currentScene.name);
    }
    public void MainMenu()
    {
        SceneController.instance.LoadScene("MainMenuScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ScoreBoard()
    {
        scoreBoardPanel.SetActive(!scoreBoardPanel.activeSelf);
    }
}
