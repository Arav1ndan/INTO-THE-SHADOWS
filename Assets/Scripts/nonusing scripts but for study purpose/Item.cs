using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    public bool isCollectable = true;
    public abstract void UseItem();

    public virtual void Collect()
    {
        Debug.Log($"{itemName} collected!");
        gameObject.SetActive(false);
    }

}
