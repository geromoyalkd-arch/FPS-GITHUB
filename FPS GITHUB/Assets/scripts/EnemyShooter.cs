using UnityEngine;
using UnityEngine.AI;

public class EnemyShooter : MonoBehaviour
{
    [Header("Stats")]
    public float detectionRange = 30f;
    public float attackRange = 20f;
    public float attackDamage = 10f;
    public float attackCooldown = 1.5f;

    [Header("Disparo")]
    public GameObject balaPrefab;
    public Transform puntoDisparo;

    private NavMeshAgent agent;
    private Transform player;
    private PlayerHealth playerHealth;
    private float attackTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null)
        {
            player = p.transform;
            playerHealth = p.GetComponent<PlayerHealth>();
        }
    }

    
    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);
        Debug.Log("Distancia al jugador: " + dist + " | AttackRange: " + attackRange);
        attackTimer -= Time.deltaTime;

        if (dist <= detectionRange)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        }

        if (dist <= attackRange)
        {
            agent.SetDestination(transform.position);
            if (attackTimer <= 0f)
            {
                attackTimer = attackCooldown;
                Disparar();
            }
        }
        else if (dist <= detectionRange)
        {
            agent.SetDestination(player.position);
        }
    }

    void Disparar()
    {
        if (balaPrefab != null && puntoDisparo != null)
        {
            
            Vector3 direccionAlJugador = (player.position - puntoDisparo.position).normalized;
            Quaternion rotacion = Quaternion.LookRotation(direccionAlJugador);
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, rotacion);
        }
    }
}