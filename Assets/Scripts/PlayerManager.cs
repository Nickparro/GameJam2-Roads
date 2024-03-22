using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private List<GameObject> acquiredTools = new List<GameObject>();
    private RaycastHit raycastHit;
    private GameObject currentToolHit;
    private float HIT_DISTANCE = 2f;
    private Camera mainCamera;
    bool isInPanic = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {

        if (canGrabObject() && currentToolHit && Input.GetKeyDown("e"))
        {
            GameObject toolToAdd = currentToolHit.GetComponent<ObjectInteraction>().getTheTool();
            if (toolToAdd != null)
            {
                toolToAdd.GetComponent<Image>().color = Color.white;
                acquiredTools.Add(toolToAdd);
                Destroy(currentToolHit);
                Debug.Log(acquiredTools.Count);
                GameManager.Instance.ActivateEnemy();
            }
            else
            {
                currentToolHit.GetComponent<Animator>().SetBool("IsOpen", true);
            }
        }
    }

    private bool canGrabObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * HIT_DISTANCE, Color.white);

        if (Physics.Raycast(ray, out RaycastHit hit, HIT_DISTANCE))
        {
            GameObject intersectedObject = hit.collider.gameObject;
            if (intersectedObject.tag == "Interactable")
            {
                currentToolHit = intersectedObject;
                currentToolHit.GetComponent<ObjectInteraction>().enableTooltipAndOutline(true);
            }
            return true;
        }

        if (currentToolHit != null && currentToolHit.tag == "Interactable")
        {
            currentToolHit.GetComponent<ObjectInteraction>().enableTooltipAndOutline(false);
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PanicEffect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemovePanicEffect();
        }
    }

    public void PanicEffect()
    {
        if (!isInPanic)
        {
            mainCamera.GetComponent<BadTVEffect>().thickDistort = 3;
            mainCamera.GetComponent<RGBShiftEffect>().amount = .0099f;
            isInPanic = true;
        }
    }

    private void RemovePanicEffect()
    {
        if (isInPanic)
        {
            mainCamera.GetComponent<BadTVEffect>().thickDistort = .2f;
            mainCamera.GetComponent<RGBShiftEffect>().amount = .0009f;
            isInPanic =false;
        }
    }

    public void TakeDamage()
    {
        GameManager.Instance.GameOver();
    }
}
