using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioClip HoverSound;
    public AudioClip ClickSound;

    public void Hover()
    {
        SoundManager.Instance.PlaySound(HoverSound, false);
    }

    public void Click()
    {
        SoundManager.Instance.PlaySound(ClickSound, false);
    }
}
