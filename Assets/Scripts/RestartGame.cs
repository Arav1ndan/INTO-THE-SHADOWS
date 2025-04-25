using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button quitButton;

    private void Start()
    {
        restartButton.onClick.AddListener(GameRestart);
        quitButton.onClick.AddListener(QuitGame);
    }
    private void GameRestart()
    {
        Scene currentSCene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(currentSCene.buildIndex);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
