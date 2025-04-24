using UnityEngine;
using UnityEngine.InputSystem;

public class Level_1_Key : Item
{
    public string keyID;
    public Door targetDoor;
    public override void UseItem()
    {
        //if(targetDoor != null)
        //{
        //    targetDoor.Unlock();
        //    Debug.Log($"{itemName} used to unlock {targetDoor.name}.");
        //}
        NewDoor[] doors = FindObjectsOfType<NewDoor>(includeInactive: false);
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
