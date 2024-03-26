using UnityEngine;
using System.Collections;

public class ScreamEffect : MonoBehaviour
{
    public Transform targetObject;
    public GameObject oldTarget;
    private float rotationSpeed = 400f;
    public bool scream = false;
    public AudioClip impact;
    int count = 0;
    Quaternion targetRotation;


    public void Screamer()
    {
        if (targetObject != null && Camera.main != null)
        {
            oldTarget.SetActive(false);
            targetObject.gameObject.SetActive(true);
            Camera.main.GetComponent<CameraController>().SetTarget(targetObject);
            Vector3 targetDirection = targetObject.position - Camera.main.transform.position;
            targetRotation = Quaternion.LookRotation(targetDirection);
            Camera.main.transform.rotation = Quaternion.RotateTowards(Camera.main.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            StartCoroutine(DeactivateScreamAfterDelay(2));
        }
    }

    private void Update()
    {
        if (scream)
        {
            Screamer();
        }
        if (count == 0 && scream)
        {
            count = 1;
            SoundManager.Instance.PlaySound(impact, false);
        }
    }


    private IEnumerator DeactivateScreamAfterDelay(float delay)
    {
        Camera.main.GetComponent<CameraController>().SetTarget(targetObject);
        yield return new WaitForSeconds(delay);
        scream = false;
        Camera.main.GetComponent<CameraController>().SetTarget(null);
        count = 0;
    }

}