using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    Dictionary<string, string> dialogsMap = new Dictionary<string, string>();
    private GameObject dialogPanelUi;
    [SerializeField]
    private TextMeshProUGUI dialogText;
    private bool dialogState = false;
    
    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        dialogPanelUi = GameObject.FindGameObjectWithTag("Dialog");
        dialogPanelUi.SetActive(false);
        dialogsMap.Add("trigger1", "First dialog");
        dialogsMap.Add("trigger2", "Second dialog");
    }

    public void HandleShowDialog(string dialog) {
        toggleDialogState(true);
        dialogText.text = dialogsMap[dialog];
    }


    public void HandleHideDialog() {
        toggleDialogState(false);
    }

    private void toggleDialogState(bool newState) {

        dialogState = newState;
        dialogPanelUi.SetActive(dialogState);
    }

}
