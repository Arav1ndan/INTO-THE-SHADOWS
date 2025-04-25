using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    public bool isLocked = true;

    [Header("Required Keys to Unlock")]
    public List<string> requiredKeyNames = new List<string>(); // Match by key name

    private HashSet<string> insertedKeyNames = new HashSet<string>();

    public void InsertKey(string keyName)
    {
        if (!requiredKeyNames.Contains(keyName))
        {
            Debug.Log($"{keyName} does not match any required key.");
            return;
        }

        if (insertedKeyNames.Contains(keyName))
        {
            Debug.Log($"{keyName} already inserted.");
            return;
        }

        insertedKeyNames.Add(keyName);
        Debug.Log($"{keyName} inserted into {name}.");

        if (insertedKeyNames.Count == requiredKeyNames.Count)
        {
            Unlock();
        }
    }

    private void Unlock()
    {
        if (isLocked)
        {
            isLocked = false;
            Debug.Log($"All keys inserted. {name} is unlocked!");
            UnlockDoor();
        }
    }

    private void UnlockDoor()
    {
        // Replace with animation/sound etc.
        Destroy(gameObject);
    }
}
