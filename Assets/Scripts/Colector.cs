using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Sb�r mince 
/// </summary>
public class Colector : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public GameObject Player;


  

    private void Start()
    {
        hintText.gameObject.SetActive(false);
        //most nen� t�eba skr�vat, je skryt�
    }

    private void Update()
    {
        //TODO: Pokud je playerInside == true a dojde ke stisku
        //      tla��tka, skryj prompt, nastav hint na "HINT: Find exit",
        //      zobraz most a skryj minci.;
        float distance = Vector3.Distance(Player.transform.position, transform.position);
        if(distance < 5f){
            hintText.gameObject.SetActive(true);
        }else{
            hintText.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown("f"))
        {
            hintText.text = "HINT: Find exit";
           // bridge.SetActive(true);
			Destroy(this.gameObject);
        }
    }

	//TODO: Zobrazit/skr�t prompt

}
