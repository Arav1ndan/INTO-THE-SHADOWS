using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked = true;
   
    public void Unlock()
    {
        if (isLocked)
        {
            isLocked = false;
            Debug.Log("Door unlocked!");
            UnlockDoor();
            
        }
    }
    private void UnlockDoor()
    {
        Destroy(gameObject);
        
    }
}
