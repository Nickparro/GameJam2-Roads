using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerTrigger : MonoBehaviour
{
    public GameObject screamer;
    public AudioClip screamAudio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(screamAudio, false);
            screamer.SetActive(true);
            Destroy(gameObject);
        }
    }
}
