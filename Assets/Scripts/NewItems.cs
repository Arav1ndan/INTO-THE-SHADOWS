using UnityEngine;

public abstract class NewItems : ScriptableObject
{

    public string itemName;
    public bool isCollectable = true;

    // Override this for each specific item behavior
    public abstract void UseItem(GameObject user);
}

