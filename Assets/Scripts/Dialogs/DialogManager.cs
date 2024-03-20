using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    Dictionary<string, string> dialogsMap = new Dictionary<string, string>();
    

    void Start()
    {
        dialogsMap.Add("trigger1", "First dialog");
        dialogsMap.Add("trigger2", "Second dialog");
    }


    public void HandleDialog(string dialog) {
        Debug.Log(dialogsMap[dialog]);
    }


}
