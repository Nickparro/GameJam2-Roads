using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundClips;
    SoundManager soundManager;
    private float minDelay = 30f;
    private float maxDelay = 90f;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        StartCoroutine(PlayRandomSound());
    }
    IEnumerator PlayRandomSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            AudioClip randomClip = soundClips[Random.Range(0, soundClips.Length)];
            soundManager.PlaySound(randomClip, false);
        }
    }
}
