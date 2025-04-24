using UnityEngine;

public class EnemyRayCastHit : MonoBehaviour
{
    public float raycastDistance = 10f;
    public LayerMask layerMask; 
    public float raycastHeight = 1.5f;

    void Update()
    {
        Vector3 rayOrigin = transform.position + Vector3.up * raycastHeight; // Offset raycast height
        Vector3 rayDirection = transform.forward; // Cast forward

        // Perform the raycast
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance, layerMask))
        {
            // Raycast hit something
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name);

            // Perform actions based on the hit object
            if (hit.collider.CompareTag("Player"))
            {
                // Do something if the hit object has the "Interactable" tag
                Debug.Log("player object detected!");
                
            }
        }
        else
        {
            //Raycast did not hit anything
            Debug.Log("Raycast did not hit anything.");
        }

        // Draw a debug ray in the Scene view
        Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, Color.red);
    }
}
