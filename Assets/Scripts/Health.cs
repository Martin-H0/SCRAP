using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public Slider healthSlider;
    // Start is called before the first frame update

    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0) health = 0;
        healthSlider.value = health;
        if (health <= 0) Destroy(gameObject);
    }
}
