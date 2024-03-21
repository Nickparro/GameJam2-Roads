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

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Road":
                player.currentFloor = FloorLayers.Road;
                break;
            case "Grass":
                player.currentFloor = FloorLayers.Grass;
                break;
            case "Dirt":
                player.currentFloor = FloorLayers.Dirt;
                break;
        }
    }
}