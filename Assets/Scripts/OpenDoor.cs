using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool isOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Open()
    {
        if (!isOpen)
        {
            transform.Rotate(0, -90f, 0);
            isOpen = true;
        }
    }
}
