using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    
    [SerializeField]
    private GameObject tooltip;
    public GameObject activateItem;
    public string textToShow = "Press K to Pickup";

    private void Awake() {
        tooltip.SetActive(false);
        tooltip.GetComponentInChildren<TextMeshProUGUI>().text = textToShow;
    }

    private void LateUpdate() {
        tooltip.transform.LookAt(tooltip.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }

    public void enableTooltipAndOutline(bool state) {
        gameObject.GetComponent<Outline>().enabled = state;
        tooltip.SetActive(state);
    }

    public GameObject getTheTool() {
        if (activateItem != null)
            return activateItem;
        return null;    
    } 
}
