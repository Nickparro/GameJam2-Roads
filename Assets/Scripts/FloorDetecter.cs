using UnityEngine;

public enum FloorLayers
{
    Road,
    Grass,
    Dirt
}

public class FloorDetecter : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Road":
                player.currentFloor = FloorLayers.Road;
                player.currentClip = player.audioClips[2];
                SoundManager.Instance.steps.clip = null;
                SoundManager.Instance.steps.Stop();
                break;
            case "Grass":
                player.currentFloor = FloorLayers.Grass;
                SoundManager.Instance.steps.clip = null;
                SoundManager.Instance.steps.Stop();
                break;
            case "Dirt":
                player.currentFloor = FloorLayers.Dirt;
                player.currentClip = player.audioClips[0];
                SoundManager.Instance.steps.clip = null;
                SoundManager.Instance.steps.Stop();
                break;
        }
    }
}