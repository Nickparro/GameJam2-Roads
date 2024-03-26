using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool hasKey = false;
    public float doorOpenAngle = 90f;
    private bool doorLocked = true;


    public void OpenDoor()
    {
        if (doorLocked && hasKey)
        {
            doorLocked = false;
            transform.rotation = Quaternion.Euler(doorOpenAngle, 0, 0);
        }
        
    }
}