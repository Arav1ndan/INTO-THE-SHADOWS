using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class GameOver : MonoBehaviour
{
    public enum LevelType
    {
       lobby,
       Level1,
       Level2,
       Info
    }

    [Header("Level to Load on Start")]
    public LevelType levelToLoad = LevelType.lobby;
    [Header("Info level ")]
    public LevelType infoToLoad = LevelType.Info;

    public Button startButton;
    public Button mainMenuButton;
    public Button QuitButton;



    
    private void Start()
    {
        startButton.onClick.AddListener(Gamestart);
        mainMenuButton.onClick.AddListener(InfoMenu);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private  void Gamestart()
    {
        string levelName = levelToLoad.ToString();

        SceneManager.LoadScene(levelName);
    }
    private void InfoMenu()
    {
        string levelName = infoToLoad.ToString();
        SceneManager.LoadScene(levelName);
    }
    private void RestartGame()
    {
        Scene currentSCene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentSCene.buildIndex);
    }
    private void QuitGame()
    {
        Debug.Log("game is quitting..");
        Application.Quit();
    }
}
