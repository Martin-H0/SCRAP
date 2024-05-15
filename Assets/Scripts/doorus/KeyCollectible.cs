using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectible : MonoBehaviour
{
    public int keyNumber;
    public GameObject Player;

    private bool isInRange = false;
    private KeyInventory stats;

    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance <5f && Input.GetKeyDown(KeyCode.F))
        {
            CollectKey();
        }
    }

    void CollectKey()
    {
        stats = Player.GetComponent<KeyInventory>();
        stats.AddKey(keyNumber);
        /* KeyInventory.Instance.AddKey(keyNumber); // P�id�n� kl��e pomoc� Singletonu */
        Debug.Log("Key " + keyNumber + " collected.");
        Destroy(gameObject);
    }
}
