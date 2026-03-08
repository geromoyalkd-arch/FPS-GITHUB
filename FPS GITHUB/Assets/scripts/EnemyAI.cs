using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float detectionRange = 15f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float attackCooldown = 1.5f;

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
        attackTimer -= Time.deltaTime;

        if (dist <= attackRange)
        {
            agent.SetDestination(transform.position);
            if (attackTimer <= 0f)
            {
                attackTimer = attackCooldown;
                if (playerHealth != null)
                    playerHealth.TakeDamage(attackDamage);
            }
        }
        else if (dist <= detectionRange)
        {
            agent.SetDestination(player.position);
        }
    }
}