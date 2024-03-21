using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody rb;
    public Transform mainCamera;
    public Slider staminaBar;
    private float maxStamina = 10f;
    private float currentStamina;
    public EnemyController enemyController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentStamina = maxStamina;
    }

    void LateUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
            {
                currentStamina -= Time.deltaTime;
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                rb.MovePosition(rb.position + moveDir.normalized * speed * 2f * Time.deltaTime);
            }
            else
            {
                currentStamina += Time.deltaTime;
                if (currentStamina > maxStamina)
                    currentStamina = maxStamina;

                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                rb.MovePosition(rb.position + moveDir.normalized * speed * Time.deltaTime);
            }
        }
        else
        {
            currentStamina += Time.deltaTime;
            if (currentStamina > maxStamina)
                currentStamina = maxStamina;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "DialogTrigger") {
            DialogManager.instance.HandleShowDialog(other.name);
            Destroy(other);
        }

        if (other.tag =="Zone1")
        {
            enemyController.TeleportEnemy(other.transform.GetChild(0).position);
        }
        else if (other.tag == "Zone2")
        {
            enemyController.TeleportEnemy(other.transform.GetChild(0).position);
        }
        else if (other.tag =="Zone3")
        {
            enemyController.TeleportEnemy(other.transform.GetChild(0).position);
        }
        else if (other.tag =="Zone4")
        {
            enemyController.TeleportEnemy(other.transform.GetChild(0).position);
        }
        else if (other.tag =="Zone5")
        {
            enemyController.TeleportEnemy(other.transform.GetChild(0).position);
        }
        else if (other.tag =="Zone6")
        {
            enemyController.TeleportEnemy(other.transform.GetChild(0).position);
        }
    }
}
