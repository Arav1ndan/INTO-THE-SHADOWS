using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class GameOver : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;
    public Button QuitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(GameRestart);
        mainMenuButton.onClick.AddListener(MainManu);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void GameRestart()
    {
        Scene currentSCene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentSCene.buildIndex);
    }
    private void MainManu()
    {
        SceneManager.LoadScene(0);
    }
    private void QuitGame()
    {
        Debug.Log("game is quitting..");
        Application.Quit();
    }
}
