using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollectible : MonoBehaviour
{
    public int gunNumber;
    public GameObject Player;
    public string gunName;

    private bool isInRange = false;
    private GunInventory stats;

    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance <5f && Input.GetKeyDown(KeyCode.F))
        {
            CollectGun();
        }
    }

    void CollectGun()
    {
        stats = Player.GetComponent<GunInventory>();
        stats.AddGun(gunNumber);
        /* GunInventory.Instance.AddGun(gunNumber); // P�id�n� kl��e pomoc� Singletonu */
        Debug.Log("Gun " + gunName + " collected.");
        Destroy(gameObject);
    }
}
