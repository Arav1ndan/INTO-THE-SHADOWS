using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public NewItems itemData;

    public InstructionSO instructionOnPickup;
    public void Collect(GameObject player)
    {
        Debug.Log($"{itemData.itemName} collected!");
        gameObject.SetActive(false);

        
        player.GetComponent<PlayerInventory>()?.AddItem(itemData);


        var instructionManager = FindObjectOfType<InstructionManager>();
        if (instructionManager != null && instructionOnPickup != null)
        {
            instructionManager.ShowInstructionDirectly(instructionOnPickup);
        }
    }
}
