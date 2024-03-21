using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public Light flashLight;
    public AudioClip flashSound;
    bool isLightOn = false;
    public Slider powerBar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashLight.enabled = !isLightOn;
            SoundManager.Instance.PlaySound(flashSound, false);
            isLightOn = !isLightOn;
        }
    }
}