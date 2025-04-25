using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public float rayDistance = 5f;  // Maximum ray length
    public LayerMask enemyLayer;    // Layer to detect enemies
    public float raySpacing = 0.5f; // Distance between side rays

    void Update()
    {
        DetectEnemies();
    }

    void DetectEnemies()
    {

        Vector3 origin = transform.position;

       
        Vector3 centerRay = origin;
        Vector3 leftRay = origin + Vector3.left * raySpacing;
        Vector3 rightRay = origin + Vector3.right * raySpacing;


        RaycastHit hitCenter, hitLeft, hitRight;

        bool centerHit = Physics.Raycast(centerRay, Vector3.down, out hitCenter, rayDistance, enemyLayer);
        bool leftHit = Physics.Raycast(leftRay, Vector3.down, out hitLeft, rayDistance, enemyLayer);
        bool rightHit = Physics.Raycast(rightRay, Vector3.down, out hitRight, rayDistance, enemyLayer);

        // Check if any ray hits an enemy
        if (centerHit)
            Debug.Log("Enemy detected at center: " + hitCenter.collider.name);
        if (leftHit)
            Debug.Log("Enemy detected at left: " + hitLeft.collider.name);
        if (rightHit)
            Debug.Log("Enemy detected at right: " + hitRight.collider.name);

        // Debug visualization (only visible in Scene view)
        Debug.DrawRay(centerRay, Vector3.down * rayDistance, centerHit ? Color.red : Color.green);
        Debug.DrawRay(leftRay, Vector3.down * rayDistance, leftHit ? Color.red : Color.green);
        Debug.DrawRay(rightRay, Vector3.down * rayDistance, rightHit ? Color.red : Color.green);
    }
}
