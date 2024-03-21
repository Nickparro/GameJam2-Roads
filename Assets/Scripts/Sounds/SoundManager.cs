using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource music, effects, steps;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip, bool isLoop)
    {
        if (!isLoop)
        {
            effects.PlayOneShot(clip);
        }
        else
        {
            effects.clip = clip;
            effects.loop = true;
            effects.Play();
        }
    }

    public void PlaySteps(AudioClip clip, bool isLoop)
    {
        if (!isLoop)
        {
            steps.PlayOneShot(clip);
        }
        else
        {
            steps.clip = clip;
            steps.loop = true;
            steps.Play();
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        music.clip = clip;
        music.loop = true;
        music.Play();
    }
}