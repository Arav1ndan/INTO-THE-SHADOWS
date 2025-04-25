using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ItemPickup>(out ItemPickup pickup))
        {
            pickup.Collect(gameObject);
        }
    }

    private void Update()
    {  
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<PlayerInventory>()?.UseItem(0);
        }
    }
}
