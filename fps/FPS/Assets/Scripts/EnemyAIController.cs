using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public float shootRange = 7f;
    public float fireRate = 3f;
    private float nextFireTime = 0f;
    private float rotationSpeed = 10f;
    public EnemyFieldOfView enemyFOV;
    public NavMeshAgent agent;
    private Vector3 currentDestination;
    public GameObject bulletPrefab;
    public float distanceToDestination;
    void Start()
    {
        enemyFOV = GetComponent<EnemyFieldOfView>();
        agent = GetComponent<NavMeshAgent>();
        currentDestination = new Vector3(0, 0, -2);
        agent.SetDestination(currentDestination);
    }
    void Update()
    {
        //Distancia al objetivo
        distanceToDestination = Vector3.Distance(currentDestination, transform.position);
        Vector3 direction;
        //Si puede ver al jugador
        if (enemyFOV.canSeePlayer)
        {
            //Si el jugador esta en el rango de tiro
            if (distanceToDestination < shootRange)
            {
                //Se queda quieto
                agent.SetDestination(transform.position);
                //Gira hacia el enemigo
                direction = enemyFOV.playerReference.transform.position - transform.position;
                direction.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
                //Dispara
                Quaternion bulletRotation = Quaternion.LookRotation(direction);
                float spawnDistance = 1.0f;
                Vector3 bulletSpawnPosition = transform.position + direction.normalized * spawnDistance;
                if (Time.time >= nextFireTime)
                {
                    Shoot(bulletSpawnPosition, bulletRotation);
                    nextFireTime = Time.time + 1f / fireRate;
                }
            }
            else
            {
                //Lo fija como objetivo
                currentDestination = enemyFOV.playerReference.transform.position;
                //Gira hacia el jugador
                direction = currentDestination - transform.position;
                direction.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                //Se mueve hacia el jugador
                agent.SetDestination(currentDestination);
            }
        }
        //Si no puede ver al enemigo
        else
        {
            //Sí llego a su ultimo objetivo fija al jugador como nuevo objetivo
            if (distanceToDestination < 2f)
            {
                currentDestination = enemyFOV.playerReference.transform.position;
            }
            //Rota hacia su objetivo
            direction = currentDestination - transform.position;
            direction.y = 0f;
            if (distanceToDestination > 1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            //Se mueve al objetivo
            agent.SetDestination(currentDestination);
        }
    }
    void Shoot(Vector3 bulletPosition, Quaternion bulletRotation)
    {
        Instantiate(bulletPrefab, bulletPosition, bulletRotation);
    }
}
