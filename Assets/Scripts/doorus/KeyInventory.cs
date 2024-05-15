using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    private static KeyInventory instance;

    private List<int> keys = new List<int>();

    // Získání instance inventáøe
    public static KeyInventory Instance
    {
        get
        {
            // Pokud instance neexistuje, vytvoøíme ji
            if (instance == null)
            {
                GameObject obj = new GameObject("KeyInventory");
                instance = obj.AddComponent<KeyInventory>();
            }
            return instance;
        }
    }

    // Pøidání klíèe do inventáøe
    public void AddKey(int keyNumber)
    {
        keys.Add(keyNumber);
        Debug.Log("Key " + keyNumber + " added to inventory.");
    }

    // Kontrola, zda hráè vlastní daný klíè
    public bool HasKey(int keyNumber)
    {
        return keys.Contains(keyNumber);
    }

    // Získání seznamu všech klíèù v inventáøi
    public List<int> GetCollectedKeys()
    {
        return keys;
    }

    // Volání této metody zaruèuje, že instance inventáøe bude existovat v prùbìhu hry
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Nepropadne s novou scénou
        }
        else
        {
            Destroy(gameObject); // Pokud existuje již jiná instance, znièíme tuto novou
        }
    }
}
