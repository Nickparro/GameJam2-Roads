using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private List<GameObject> acquiredTools = new List<GameObject>();
    private RaycastHit raycastHit;
    private GameObject currentToolHit;
    private float HIT_DISTANCE = 2f;
    private int NUMBER_OF_TOOLS = 2;
    private Camera mainCamera;
    bool isInPanic = false;
    ScreamEffect screamer;
    public EnemyController enemyController;
    public AudioClip heartBeat;
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
        screamer = GetComponent<ScreamEffect>();
    }

    private void Update()
    {
        Debug.Log(HasAllTheTools());

        if (canGrabObject() && currentToolHit && Input.GetKeyDown("e")) {
            GameObject toolToAdd = currentToolHit.GetComponent<ObjectInteraction>().getTheTool();
            if (toolToAdd != null) {
                toolToAdd.GetComponent<Image>().color = Color.white;
                acquiredTools.Add(toolToAdd);
                if (currentToolHit.GetComponent<ObjectInteraction>().isOneShotActivation
                    && currentToolHit.gameObject.name == "Tendero"
                    && currentToolHit.GetComponent<ObjectInteraction>().enabled
                ) {
                    DialogManager.instance.SetDialog();
                    currentToolHit.GetComponent<ObjectInteraction>().enabled = false;
                    FindObjectOfType<DoorController>().hasKey = true;
                    currentToolHit.GetComponent<ObjectInteraction>().resetToolTip();
                } else {
                    TextMeshProUGUI goalText = GameObject.Find("GoalText").GetComponent<TextMeshProUGUI>();
                    goalText.text = "Back to car to put on gas"; 
                    GameManager.Instance.ActivateEnemy();
                    screamer.scream = true;
                    Destroy(currentToolHit);
                }   
                
            } else {
                if (currentToolHit.GetComponent<ObjectInteraction>().isFinalState && HasAllTheTools()) {
                    GameManager.Instance.playerWin = true;
                    Debug.Log(GameManager.Instance.playerWin);
                }
                else if (currentToolHit.gameObject.name == "Door_03") {
                    currentToolHit.GetComponent<Animator>().SetBool("IsOpen", true);
                    SoundManager.Instance.PlaySound(currentToolHit.GetComponent<ObjectInteraction>().audoToplayOnAnim, false);
                    StartCoroutine(ApplyAnimations(2, currentToolHit.GetComponent<Animator>(), "IsOpen", false));
                }
                else if (currentToolHit.GetComponent<DoorController>() != null)
                {
                    SoundManager.Instance.PlaySound(currentToolHit.GetComponent<ObjectInteraction>().audoToplayOnAnim, false);
                    currentToolHit.GetComponent<DoorController>().OpenDoor();
                }
            }
        }
    }

    IEnumerator ApplyAnimations(float time, Animator animator, string flag, bool value) {
        yield return new WaitForSeconds(time);
        animator.SetBool(flag, value);   
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
                if (currentToolHit.GetComponent<ObjectInteraction>().isFinalState ) {
                    if (HasAllTheTools())
                        currentToolHit.GetComponent<ObjectInteraction>().enableTooltipAndOutline(true);
                } else {
                    currentToolHit.GetComponent<ObjectInteraction>().enableTooltipAndOutline(true);
                }
            }
            return true;
        }

        if (currentToolHit != null && currentToolHit.tag == "Interactable")
        {
            currentToolHit.GetComponent<ObjectInteraction>().enableTooltipAndOutline(false);
        }
        return false;
    }

    private bool hasDetectedColision = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PanicEffect();
            SoundManager.Instance.PlayHeartBeat(heartBeat);
        }
        else if (other.CompareTag("DialogTrigger") && !hasDetectedColision)
        {
            DialogManager.instance.SetDialog();
            hasDetectedColision = true;
        }
        else if (other.CompareTag("Zone1") || other.CompareTag("Zone2") || other.CompareTag("Zone3") ||
                 other.CompareTag("Zone4") || other.CompareTag("Zone5") || other.CompareTag("Zone6"))
        {
            enemyController.TeleportEnemy(other.transform.GetChild(0).position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            RemovePanicEffect();
            SoundManager.Instance.StopHeartBeat(heartBeat);
        }
        if (other.CompareTag("DialogTrigger") && hasDetectedColision)
        {
            hasDetectedColision = false;
            Destroy(other.gameObject);
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

    /*public void TakeDamage()
    {
        GameManager.Instance.GameOver();
    }*/

    public bool HasAllTheTools() {
        return acquiredTools.Count == NUMBER_OF_TOOLS;
    } 
}
