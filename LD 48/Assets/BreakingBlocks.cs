using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingBlocks : MonoBehaviour
{
    [SerializeField] private bool broke;
    [SerializeField] private bool held;
    [SerializeField] private GameObject player;
    private float _result;
    public Inventory Inventory;

    private void Awake()
    {
        player = GameObject.Find("Player");
        
   
        
    }

    private void OnDestroy()
    {
        switch (this.gameObject.name)
        {
            case "Grass":
                Inventory.inventory[0] = Inventory.inventory[0] + 1;
                break;
            case "dirt":
                Inventory.inventory[1] = Inventory.inventory[1] + 1;
                break;
            case "rock":
                Inventory.inventory[2] += Inventory.inventory[2] + 1;
                break;
            case "iron":
                Inventory.inventory[3] += Inventory.inventory[3] + 1;
                break;
            case "gold":
                Inventory.inventory[4] += Inventory.inventory[4] + 1;
                break;
            case "diamond":
                Inventory.inventory[5] += Inventory.inventory[5] + 1;
                break;
        }
    }

    private void Update()
    {
       
        
        
         _result = Vector3.SqrMagnitude(player.gameObject.transform.position - this.transform.position);
        if (broke)
        {
           Destroy(gameObject);
        }
        
        
        held = Input.GetButton("Fire1");
        
    }


    private void OnMouseDown()
    {
        if (_result < 25f)
        {

            held = Input.GetButton("Fire1");

           
            if (held)
            {
                StartCoroutine(breakTimer());
            }
        }


    }

    IEnumerator breakTimer()
    {
        yield return new WaitForSeconds(1f);
        broke = held;
    }

    
}
