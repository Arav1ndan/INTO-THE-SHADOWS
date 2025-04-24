using System.Collections;
using UnityEngine;

public class RobotController : MonoBehaviour ,IRobotController
{

    [SerializeField] private Light RobotLight;
    [SerializeField] private Collider DetectionCollider;
    private string HexColorCode = "#BD1D35";

    [SerializeField] private bool shouldBlink = false;
    [SerializeField] private float blinkInterval = 0.5f;
     
    private Coroutine blinkCoroutine;

    private void Awake()
    {
        if (RobotLight == null)
            RobotLight = GetComponentInChildren<Light>();

        if(DetectionCollider == null)
            DetectionCollider = GetComponentInChildren<Collider>();
    }
    private void Start()
    {
        if (shouldBlink)
            StartBlinking(blinkInterval);
    }
    public void ApplyLightColor(Color color)
    {
        if (RobotLight != null)
        {
            RobotLight.color = color;
        }
        else
        {
            Debug.LogWarning("[RobotController] No Light component found.");
        }
    }

    public void StartBlinking(float interval)
    {
        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);

        blinkCoroutine = StartCoroutine(BlinkLight(interval));
    }

    public void StopBlinking()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
        }

        if (RobotLight != null)
        {
            RobotLight.enabled = true;
            DetectionCollider.enabled = true;
        }
            
            
    }

    private IEnumerator BlinkLight(float interval)
    {
        while (true)
        {
            if (RobotLight != null)
            {
                RobotLight.enabled = !RobotLight.enabled;
                DetectionCollider.enabled = !DetectionCollider.enabled;
            }
               

            yield return new WaitForSeconds(interval);
        }
    }
}
