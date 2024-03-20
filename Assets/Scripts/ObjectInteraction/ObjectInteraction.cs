using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    
    [SerializeField]
    private GameObject tooltip;
    public string textToShow = "Press K to Pickup";

    private void Awake() {
        tooltip.SetActive(false);
        tooltip.GetComponentInChildren<TextMeshProUGUI>().text = textToShow;
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableTooltipAndOutline(bool state) {
        gameObject.GetComponent<Outline>().enabled = state;
        tooltip.SetActive(state);
    }
}
