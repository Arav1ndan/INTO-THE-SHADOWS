using GoSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public enum LevelType
    {
        lobby,
        level1,
        level2,
    }
    [Header("Level to Load on Start")]
    public LevelType levelToLoad = LevelType.level2;
    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
        {
            Debug.Log("nother entered");
        }
            
        GoCharacterController playerController = other.GetComponent<GoCharacterController>();
        if (playerController)
        {
            nextLevel();
        }
    }

    private void nextLevel()
    {
        string levelName = levelToLoad.ToString();

        SceneManager.LoadScene(levelName);
    }
}
