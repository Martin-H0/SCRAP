using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInventory : MonoBehaviour
{
    private static GunInventory instance;

    private List<int> guns = new List<int>();

    // Z�sk�n� instance invent��e
    public static GunInventory Instance
    {
        get
        {
            // Pokud instance neexistuje, vytvo��me ji
            if (instance == null)
            {
                GameObject obj = new GameObject("GunInventory");
                instance = obj.AddComponent<GunInventory>();
            }
            return instance;
        }
    }

    // P�id�n� kl��e do invent��e
    public void AddGun(int gunNumber)
    {
        guns.Add(gunNumber);
        Debug.Log("Gun " + gunNumber + " added to inventory.");
    }

    // Kontrola, zda hr�� vlastn� dan� kl��
    public bool HasGun(int gunNumber)
    {
        return guns.Contains(gunNumber);
    }

    // Z�sk�n� seznamu v�ech kl��� v invent��i
    public List<int> GetCollectedGuns()
    {
        return guns;
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
