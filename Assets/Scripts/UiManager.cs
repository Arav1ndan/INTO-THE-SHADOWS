using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;

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
}
