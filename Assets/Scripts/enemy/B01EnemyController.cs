using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B01EnemyController : MonoBehaviour
{
    public Transform Player; // Reference na hr��ovu pozici
    public float spawnDistance = 12f; // Vzd�lenost, ve kter� se m� nep��tel zobrazit
    public float chaseDistance = 6f; // Vzd�lenost, ve kter� se nep��tel za�ne hr��e pron�sledovat
    public float movementSpeed = 3f; // Rychlost pohybu nep��tele
    public int damage =10; // �jma zp�soben� nep��telem hr��i
    public int health=80; // �ivoty nep��tele

    private bool isChasing = false;

    private MeshRenderer meshRenderer;



    void Start()
    {
        // Spust�me funkci pro kontrolu hr��e ka�d�ch 0.1 sekundy
        InvokeRepeating("CheckPlayerDistance", 0, 0.1f);
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.enabled = false; 
        }
        
    }

    void Update()
    {
        // Pokud nep��tel pron�sleduje hr��e
        if (isChasing)
        {
            // Pohneme sm�rem k hr��i
            transform.position = Vector3.MoveTowards(transform.position, Player.position, movementSpeed * Time.deltaTime);
        }
    }
    
    void CheckPlayerDistance()
    {
        // Vypo�teme vzd�lenost mezi hr��em a nep��telem
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        // Pokud je hr�� v dostate�n� vzd�lenosti, zobraz�me nep��tele
        if (distanceToPlayer <= spawnDistance)
        {
            meshRenderer.enabled = true; 
        }

        // Pokud je hr�� v dostate�n� vzd�lenosti a nep��tel je�t� nep�esleduje hr��e, za�ne ho pron�sledovat
        if (distanceToPlayer <= chaseDistance && !isChasing)
        {
            isChasing = true;
        }

        // Pokud je hr�� v dostate�n� vzd�lenosti a nep��tel je�t� nep�esleduje hr��e, za�ne ho pron�sledovat
        if (distanceToPlayer <= chaseDistance && !isChasing)
        {
            isChasing = true;
        }

        // Pokud je nep��tel u hr��e, zp�sobuje hr��i �jmu
        if (distanceToPlayer <= 1f)
        {
            Player.GetComponent<Health>().TakeDamage(damage);
        }
    }

    // Metoda pro ub�r�n� �ivot� nep��teli
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
