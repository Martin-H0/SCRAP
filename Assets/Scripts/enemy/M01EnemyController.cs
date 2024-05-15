using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class M01EnemyController : MonoBehaviour
{
    public Transform player;
    public float spawnDistance;
    public float chaseDistance;
    public float shootDistance;
    public float movementSpeed;
    public float runDistance;
    public int health;
    public GameObject projectilePrefab;

    public double shootDelay;
    private double shootTime = 0;

    private bool isChasing = false;
    private bool isShooting = false;
    private bool isFleeing = false;
     private MeshRenderer meshRenderer;

     public  NavMeshAgent agent;
    

    void Start()
    {
        // Kontrola vzd�lenosti hr��e v pravideln�ch intervalech
        /* InvokeRepeating("CheckPlayerDistance", 0, 0.1f); */
        meshRenderer = GetComponent<MeshRenderer>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false; 
            agent.enabled = false; 
        }
    }

    void Update()
    {
        // Chov�n� nep��tele v z�vislosti na jeho stavu
        CheckPlayerDistance();
        if (isChasing && !isFleeing)
        {
             agent.destination = player.position;
            //ggggggggggg
            if (Vector3.Distance(transform.position, player.position) <= shootDistance)
            {
                isShooting = true;
                isChasing = false;
            }
        }
        else if (isFleeing && !isChasing)
        {
            agent.destination = transform.position - (player.position - transform.position);
        }
        else if (!isChasing && !isFleeing)
        {
            agent.destination = transform.position;
        }

        if (isShooting)
        {
            Shoot();
        }
    }

    void CheckPlayerDistance()
    {
        // Kontrola vzd�lenosti hr��e a reakce na ni
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= spawnDistance)
        {
            meshRenderer.enabled = true; 
            agent.enabled = true; 
            isChasing = false;
            isShooting = false;
            isFleeing = false;
        }

        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
            isShooting = false;
            isFleeing = false;
        }

        if (distanceToPlayer <= shootDistance)
        {
            isShooting = true;
            isChasing = false;
            isFleeing = false;
        }

        if (distanceToPlayer <= runDistance)
        {
            isFleeing = true;
            isChasing = false;
            isShooting = false;
        }
    }

    void Shoot()
    {
        shootTime += Time.deltaTime;
        if (shootTime >= shootDelay)
        {
            shootTime = 0;
            // St�elba projektilu sm�rem k hr��i
            Vector3 direction = (player.position - transform.position).normalized;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            ProjectileController projectileController = projectile.GetComponent<ProjectileController>();
            projectileController.Init(direction);
            isShooting = false;
        }
    }

    /// <summary>
    /// Metoda pro zpracov�n� �jmy na nep��teli.
    /// </summary>
    /// <param name="damageAmount">Mno�stv� �jmy.</param>
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
