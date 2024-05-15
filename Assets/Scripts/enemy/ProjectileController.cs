using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    public int damage;

    private float lifetime = 10f;
    private float currentLifetime = 0f;

    /// <summary>
    /// Inicializuje parametry projektilu.
    /// </summary>
    /// <param name="_direction">Sm�r pohybu projektilu.</param>
    /// <param name="_speed">Rychlost projektilu.</param>
    /// <param name="_damage">�jma zp�soben� projektilu hr��i.</param>
    public void Init(Vector3 _direction)
    {
        direction = _direction;
    }

    void Update()
    {
        Move();
        CheckLifetime();
    }

    void Move()
    {
        // Pohyb projektilu po sm�ru
        transform.position += direction * speed * Time.deltaTime;
    }

    void CheckLifetime()
    {
        // Kontrola �ivotnosti projektilu
        currentLifetime += Time.deltaTime;
        if (currentLifetime >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Detekce kolize s hr��em a aplikace �jmy
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
