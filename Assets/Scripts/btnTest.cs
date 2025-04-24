using UnityEngine;
using UnityEngine.UI;


public class btnTest : MonoBehaviour
{
    public Image Imagebutton;
    private void Start()
    {
        if (Imagebutton == null)
        {
            Imagebutton = GetComponentInChildren<Image>();
        }
    }
    public void OnClickShow()
    {
        if (Imagebutton != null)
        {
            Debug.Log("Button clicked on ");
            Color color = Imagebutton.color;
            color.a = 1; // Alpha should be between 0 and 1
            Imagebutton.color = color;
        }
        else
        {
            Debug.LogError("Imagebutton is not assigned or found!");
        }
    }

}
