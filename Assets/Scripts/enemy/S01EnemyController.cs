using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S01EnemyController : MonoBehaviour
{
    public Transform player;
    public float spawnDistance;
    public float chaseDistance;
    public float spawnInterval = 5f; // Interval mezi spawnov�n�m
    public GameObject enemyPrefab; // Prefab nep��tele, kter� bude spawnov�n

    private bool isChasing = false;
    private bool isSpawning = false;

    void Start()
    {
        // Kontrola vzd�lenosti hr��e v pravideln�ch intervalech
        InvokeRepeating("CheckPlayerDistance", 0, 0.1f);
    }

    void Update()
    {
        // Pokud je nep��tel v re�imu pron�sledov�n� hr��e
        if (isChasing)
        {
            // Pokud je�t� nen� v re�imu spawnov�n�, spust�me spawnov�n� v pravideln�ch intervalech
            if (!isSpawning)
            {
                isSpawning = true;
                InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
            }

            // Pohyb sm�rem k hr��i
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime);
        }
    }

    void CheckPlayerDistance()
    {
        // Kontrola vzd�lenosti hr��e a reakce na ni
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= spawnDistance)
        {
            gameObject.SetActive(true);
        }

        if (distanceToPlayer <= chaseDistance && !isChasing)
        {
            isChasing = true;
        }
    }

    void SpawnEnemy()
    {
        // Spawnov�n� nov�ho nep��tele
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
