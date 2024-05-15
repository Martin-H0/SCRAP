/* using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sb�r mince 
/// </summary>
public class Collectable : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public GameObject Player;


    private bool playerInside = false;

    private void Start()
    {
        hintText.SetActive(false);
        //most nen� t�eba skr�vat, je skryt�
    }

    private void Update()
    {
        //TODO: Pokud je playerInside == true a dojde ke stisku
        //      tla��tka, skryj prompt, nastav hint na "HINT: Find exit",
        //      zobraz most a skryj minci.;
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(distance < 5f){
            hintText.SetActive(true);
        }else{
            hintText.SetActive(false);
        }
        if (playerInside && Input.GetKeyDown("e"))
        {
            hintText.text = "HINT: Find exit";
           // bridge.SetActive(true);
            playerInside = false;
			Destroy(gameObject);
        }
    }

	//TODO: Zobrazit/skr�t prompt

}
 */