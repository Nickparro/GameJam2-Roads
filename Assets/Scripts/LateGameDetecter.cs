using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateGameDetecter : MonoBehaviour
{
    [SerializeField] private AudioClip gasStationClip;
    bool isInside = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isInside)
            {
                SoundManager.Instance.PlayMusic(gasStationClip);
            }
            else
            {
                GameManager.Instance.LateGameStart();
                Destroy(gameObject);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = true;
    }
}
