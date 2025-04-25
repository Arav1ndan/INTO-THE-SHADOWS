using GoSystem;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    private Light DetectionLight;
    [SerializeField]
    private RobotController robotController;
    [SerializeField]
    private string ColorHex = "#BD1D35";

    private void Awake()
    {
        DetectionLight = GetComponent<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GoCharacterController playerController = other.GetComponent<GoCharacterController>();
        if (playerController)
        {
            Debug.Log("Player found");
           
            PlayerSpotted();
            //PlayerDied(playerController);
            UiManager.Instance.ShowGameOverPanel();
        }       
    }
    private void PlayerSpotted()
    {
        Color color;
        if (ColorUtility.TryParseHtmlString("#BD1D35", out color))
        {
            robotController.ApplyLightColor(color);
        }
    }
    private void PlayerDied(GoCharacterController playerController) 
    {
        playerController.enabled = false;
    }
}
