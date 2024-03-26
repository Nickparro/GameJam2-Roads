using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool hasKey;
    public float doorOpenAngle = 90f;
    private bool doorLocked = true;


    public void OpenDoor()
    {
        if (doorLocked)
        {
            doorLocked = false;
            transform.rotation = Quaternion.Euler(doorOpenAngle, 0, 0);
        }
        
    }
}