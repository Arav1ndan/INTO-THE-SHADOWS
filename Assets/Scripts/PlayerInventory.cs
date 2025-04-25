using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<NewItems> collectedItems = new List<NewItems>();

    public void AddItem(NewItems item)
    {
        collectedItems.Add(item);
        Debug.Log($"{item.itemName} added to inventory.");
    }

    public void UseItem(int index)
    {
        if (index >= 0 && index < collectedItems.Count)
        {
            collectedItems[index].UseItem(gameObject);
            collectedItems.RemoveAt(index); // optional: consume on use
        }
    }
}
