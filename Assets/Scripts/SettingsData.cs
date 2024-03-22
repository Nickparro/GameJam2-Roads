using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData : MonoBehaviour
{

    public static SettingsData Instance;
    public float sensValue = 100;
    public float mainVolume = 0;
    public Resolution currentResolution;
    public bool isFullScreen = false;
    public int currentQualityIndex;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }


}
