using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demager : MonoBehaviour
{
    private IEnumerator damageCourotine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            damageCourotine = giveDamage(other);
            StartCoroutine(damageCourotine);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(damageCourotine);
        }
    }

    private IEnumerator giveDamage(Collider player)
    {
        while (true)
        {
            player.GetComponent<Health>().TakeDamage(5);

            yield return new WaitForSeconds(5f);
        }
    }
}
