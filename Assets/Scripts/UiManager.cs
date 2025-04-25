using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    [SerializeField]
    private TextMeshProUGUI InstructionText;
    [SerializeField]
    private CanvasGroup CanvasGroup;
    [SerializeField]
    private float FadeDuration = 0.5f;

    [SerializeField]
    private GameObject GameoverPanel;
    [SerializeField]
    private Button restartButton;
    [SerializeField]
    private Button quitGame;
      
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }

    }
    private void Start()
    {
        if(restartButton != null)
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }
        if (GameoverPanel != null)
        {
            GameoverPanel.SetActive(false);
        }
    }

    public void ShowInstruction(string text)
    {
        StopAllCoroutines();
        InstructionText.text = text;
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        CanvasGroup.alpha = 0;
        float timer = 0f;
        while (timer < FadeDuration)
        {
            CanvasGroup.alpha = Mathf.Lerp(0, 1, timer / FadeDuration);
            timer += Time.deltaTime;
            yield return null;
        }
        CanvasGroup.alpha = 1;
    }

    public void ShowGameOverPanel()
    {
        GameoverPanel.SetActive(true);
    }
    public void OnRestartButtonClicked()
    {
        Debug.Log("Restart button clicked!"); 
        if (GameoverPanel != null)
        {
            GameoverPanel.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
