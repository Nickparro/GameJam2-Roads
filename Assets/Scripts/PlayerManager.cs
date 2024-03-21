using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private List<string> acquiredTools = new List<string>();
    private RaycastHit raycastHit;
    private GameObject currentToolHit;
    private float HIT_DISTANCE = 2f;
    
    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update() {

        if (canGrabObject() && currentToolHit && Input.GetKeyDown("e")) {
            acquiredTools.Add(currentToolHit.name);
            Destroy(currentToolHit);
            Debug.Log(acquiredTools.ToString());
        }
    }

    private bool canGrabObject() {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * HIT_DISTANCE,  Color.white);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, HIT_DISTANCE)) {
            GameObject intersectedObject = raycastHit.collider.gameObject;
            if (intersectedObject.tag == "Interactable") {
                Debug.Log("HIT intectac");
                currentToolHit = intersectedObject;
                currentToolHit.GetComponent<ObjectInteraction>().enableTooltipAndOutline(true);
                
            }
            return true;
        }

        if (currentToolHit != null && currentToolHit.tag == "Interactable") {
            currentToolHit.GetComponent<ObjectInteraction>().enableTooltipAndOutline(false);
        }
        return false;
    }



}
