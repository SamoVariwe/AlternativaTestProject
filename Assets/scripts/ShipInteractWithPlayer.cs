using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInteractWithPlayer : MonoBehaviour
{
    private bool ShowInteractionLabel = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            if (Input.GetKey(KeyCode.E))
            {
               
                ControlDestributor.Instance.SwitchPlayerShip();
                collision.gameObject.SetActive(false);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowInteractionLabel = true;
       
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowInteractionLabel = false ;
            
        }
    }

    private void OnGUI()
    {
        if(ShowInteractionLabel)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "E to enter the Ship");
        }
    }

}
