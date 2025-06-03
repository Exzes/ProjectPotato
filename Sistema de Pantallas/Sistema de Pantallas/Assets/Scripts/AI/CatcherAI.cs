using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CatcherAI : MonoBehaviour
{
    public enum State { Patrol, Chase }
    private State currentState = State.Patrol;


    //estados posibles para la AI del enemigo en su maquina de estados
    [Header("Patrolling")]
    public List<Transform> patrolPoints;
    public float waitTime = 2f;

    [Header("Chasing")]
    public float chaseSpeed = 5f;
    public float patrolSpeed = 2f;
    public float loseSightTime = 3f;

    private int currentPoint = 0;
    private float waitTimer;
    private float timeSinceLastSeen;
    private NavMeshAgent agent;

    //configuramos todas las variables de vision bajo un mismo header por comodidad (no afecta el funcionamiento de la logica)
    [Header("Vision")]
    public float viewAngle = 45f;
    public float viewDistance = 10f;
    //public LayerMask playerMask;

    public LayerMask obstacleMask;
    public Transform player;

    private bool presentation = true;
    private float originalWaitTime;


    void Start()
    {
        //tomamos el componente de agente y configuramos sus propiedades
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        agent.SetDestination(patrolPoints[currentPoint].position);
        originalWaitTime = waitTime;
        CatcherPresentation();
    }

    void Update()
    {
        switch (currentState) //estado actual en el que se encuentra la AI del NPC
        {
            //en patrullaje
            case State.Patrol:
                Patrol();
                if (CanSeePlayer())
                {
                    currentState = State.Chase;
                    agent.speed = chaseSpeed;
                }
                break;

            //en persecuci�n
            case State.Chase:
                agent.SetDestination(player.position);

                //si vemos al player entonces la ultima vez que lo vimos es ahora mismo
                if (CanSeePlayer())
                {
                    timeSinceLastSeen = 0f;
                }
                else
                {
                    //en cambio si no lo vemos sumamos tiempo hasta que superamos el valor de cooldown de persecuci�n
                    timeSinceLastSeen += Time.deltaTime;
                    if (timeSinceLastSeen >= loseSightTime)
                    {
                        currentState = State.Patrol;
                        agent.speed = patrolSpeed;
                        agent.SetDestination(patrolPoints[currentPoint].position);
                    }
                }
                break;
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance < 0.5f && !agent.pathPending)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Count;
                agent.SetDestination(patrolPoints[currentPoint].position);
                waitTimer = 0f;
            }
        }
    }

    bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        //si podemos ver en el cono que estamos proyectando
        //y la distancia al jugador esta dentro de nuestra distancia de vision
        //y la proyeccion que estamos realizando no esta obstruida por un obstaculo
        //dadas por completadas todas estas validaciones, podemos ver al jugador
        if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
        {
            if (distanceToPlayer < viewDistance)
            {
                if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                {
                    return true;
                }
            }
        }
        return false;
    }
    void CatcherPresentation()
    {
        if (presentation)
        {
            presentation = false;
            waitTime = 8;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OffPresentation"))
        {
            waitTime = originalWaitTime;
        }
    }
}