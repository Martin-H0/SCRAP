using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int doorNumber;
    public GameObject Player;

    void Update()
    {
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if (distance <5f && Input.GetKeyDown(KeyCode.F))
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (KeyInventory.Instance.HasKey(doorNumber)) // Kontrola kl��e pomoc� Singletonu
        {
            Debug.Log("Door " + doorNumber + " dorr goes brrr.");
            gameObject.SetActive(false); // Deaktivuje dve�e
        }
        else
        {
            Debug.Log("Incorrect key! skyll issue.");
        }
    }
}
