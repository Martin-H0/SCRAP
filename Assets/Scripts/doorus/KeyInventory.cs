using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    private static KeyInventory instance;

    private List<int> keys = new List<int>();

    // Z�sk�n� instance invent��e
    public static KeyInventory Instance
    {
        get
        {
            // Pokud instance neexistuje, vytvo��me ji
            if (instance == null)
            {
                GameObject obj = new GameObject("KeyInventory");
                instance = obj.AddComponent<KeyInventory>();
            }
            return instance;
        }
    }

    // P�id�n� kl��e do invent��e
    public void AddKey(int keyNumber)
    {
        keys.Add(keyNumber);
        Debug.Log("Key " + keyNumber + " added to inventory.");
    }

    // Kontrola, zda hr�� vlastn� dan� kl��
    public bool HasKey(int keyNumber)
    {
        return keys.Contains(keyNumber);
    }

    // Z�sk�n� seznamu v�ech kl��� v invent��i
    public List<int> GetCollectedKeys()
    {
        return keys;
    }

    // Vol�n� t�to metody zaru�uje, �e instance invent��e bude existovat v pr�b�hu hry
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Nepropadne s novou sc�nou
        }
        else
        {
            Destroy(gameObject); // Pokud existuje ji� jin� instance, zni��me tuto novou
        }
    }
}
