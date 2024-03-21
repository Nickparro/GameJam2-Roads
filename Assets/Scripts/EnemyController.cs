using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent aiNav;
    [SerializeField] Transform playerPos;
    [SerializeField] Transform carPos;
    [SerializeField] Transform middleMap;
    [SerializeField] Transform gasStationPos;
    [SerializeField] Vector3 enemyDestination;
    [SerializeField] float minSpeed = 2f;
    [SerializeField] float maxSpeed = 10f;
    public float actualSpeed;
    public Animator enemyAnim;
    [SerializeField] AudioClip stepGrass;
    public float damageDistance = 5f;
    void Start()
    {
        aiNav.speed = minSpeed;
        enemyAnim.SetBool("isRunning", false);
    }

    void Update()
    {
        enemyDestination = playerPos.position;
        aiNav.destination = enemyDestination;
        actualSpeed = aiNav.speed;
        SpeedUpdate();
        changeAnimation();
        HurtPlayer();
    }

    void SpeedUpdate()
    {
        float distanceToFinal = Vector3.Distance(playerPos.position, carPos.position);
        float maxDistance = Vector3.Distance(gasStationPos.position, carPos.position);

         if (maxDistance > 0)
        {
            // Calcula un factor de interpolación basado en la distancia actual.
            float t = 1 - (distanceToFinal / maxDistance);
            
            // Interpola entre la velocidad mínima y máxima basado en t.
            aiNav.speed = Mathf.Lerp(minSpeed, maxSpeed, t);
        }

    }

    void changeAnimation()
    {
        if(playerPos.position.x < middleMap.position.x)
        {
            enemyAnim.SetBool("isRunning", true);
        } else if (playerPos.position.x > middleMap.position.x)
        {
            enemyAnim.SetBool("isRunning", false);
        }
    }
    public void TeleportEnemy(Vector3 teleportPoint)
    {
        aiNav.Warp(teleportPoint);
    }

    void HurtPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);
        if (distanceToPlayer <= damageDistance)
        {
            playerPos.GetComponent<PlayerManager>().TakeDamage();
        }
    }

}
