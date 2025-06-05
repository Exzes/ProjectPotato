using UnityEngine;

public class FlyerAI : MonoBehaviour
{
    [Header("Spawn, Movement, Detection")]
    public float detectionRadius = 10f;
    public float moveSpeed = 5f;
    public float stoppingDistance = 1f;
    public Transform startPoint;

    [Header("Vision")]
    public float viewAngle = 45f;
    public float viewDistance = 10f;
    public LayerMask obstacleMask;
    public Transform player;
    private Animator _anim;

    private enum State
    {
        Idle,
        Chasing
    }

    private State currentState = State.Idle;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        // if (!PlayManager.Instance.canEnemiesAtk)
        // {
        //     _anim.SetBool("PlayerDetected", false);
        //     _anim.SetBool("Persecution", false);
        //     return;
        // }

        switch (currentState) //estado actual en el que nos encontramos
        {
            case State.Idle:
                HandleIdle();
                break;
            case State.Chasing:
                HandleChasing();
                break;
        }

        UpdateState();
    }

    void HandleIdle()
    {
        float distanceToStart = Vector3.Distance(transform.position, startPoint.position); //vamos a medir si estamos lo suficientemente lejos del punto de origen
        if (distanceToStart > stoppingDistance)
        {
            MoveTowards(startPoint.position); //para movernos al punto de spawn del enemigo
        }
        else
        {
            _anim.SetBool("PlayerDetected", false);
            _anim.SetBool("Persecution", false);
            _anim.SetBool("OnSpot", true);
        }
    }

    void HandleChasing()
    {
        if (player != null)
        {
            MoveTowards(player.position); //seguir la player
            _anim.SetBool("Persecution", true);
        }
    }

    void UpdateState()
    {
        if (PlayerInSight())
        {
            currentState = State.Chasing;
            _anim.SetBool("PlayerDetected", true);
            _anim.SetBool("OnSpot", false);
        }
        else
        {
            currentState = State.Idle;
        }
    }

    bool PlayerInSight()
    {
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized; //normalizamos la direccion al player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            //si podemos ver en el cono que estamos proyectando
            //y la distancia al jugador esta dentro de nuestra distancia de vision
            //y la proyeccion que estamos realizando no esta obstruida por un obstaculo
            //dadas por completadas todas estas validaciones, podemos ver al jugador
            if (Vector3.Angle(transform.forward, directionToPlayer) < viewAngle / 2)
            {
                if (distanceToPlayer < viewDistance)
                {
                    if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask)) //chequeamos que no estemos impactando en la capa de obstaculo
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    void MoveTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // mirar en direccion a donde nos movemos
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * 5f); //nunca voy a terminar de entender slerp pero nos deja transicionar de forma comoda la rotacion entre dos puntos
        }
    }
}