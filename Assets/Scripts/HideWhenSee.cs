using UnityEngine;

public class HideWhenSee : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = true;    
    }
    void Start()
    {
        //meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnBecameVisible()
    {
        // Hide the object when it's visible to the camera
        meshRenderer.enabled = false;
    }

    void OnBecameInvisible()
    {
        // Show the object when it's outside the camera view
        meshRenderer.enabled = true;
    }
}
