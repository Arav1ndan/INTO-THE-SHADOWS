using UnityEngine;

[CreateAssetMenu(fileName = "New Key", menuName = "Items/Key")]
public class KeyItem : NewItems
{
    public string keyID;

    public override void UseItem(GameObject user)
    {
        NewDoor[] doors = GameObject.FindObjectsOfType<NewDoor>();

        foreach (NewDoor door in doors)
        {
            if (door.isLocked && door.requiredKeyNames.Contains(keyID))
            {
                door.InsertKey(keyID);
                Debug.Log($"{itemName} used on {door.name}.");
                return;
            }
        }

        Debug.Log($"{itemName} doesn't match any door.");
    }
}
