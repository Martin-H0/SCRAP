using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S01EnemyController : MonoBehaviour
{
    public Transform player;
    public float spawnDistance;
    public float chaseDistance;
    public float spawnInterval = 5f; // Interval mezi spawnováním
    public GameObject enemyPrefab; // Prefab nepøítele, který bude spawnován

    private bool isChasing = false;
    private bool isSpawning = false;

    void Start()
    {
        // Kontrola vzdálenosti hráèe v pravidelných intervalech
        InvokeRepeating("CheckPlayerDistance", 0, 0.1f);
    }

    void Update()
    {
        // Pokud je nepøítel v režimu pronásledování hráèe
        if (isChasing)
        {
            // Pokud ještì není v režimu spawnování, spustíme spawnování v pravidelných intervalech
            if (!isSpawning)
            {
                isSpawning = true;
                InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
            }

            // Pohyb smìrem k hráèi
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime);
        }
    }

    void CheckPlayerDistance()
    {
        // Kontrola vzdálenosti hráèe a reakce na ni
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
        // Spawnování nového nepøítele
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
