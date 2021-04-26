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
    [SerializeField] private float BreakTime = 1f;
    public Inventory inventory;
    public Shop shop;
    private void Awake()
    {
        player = GameObject.Find("Player");
        inventory =   player.GetComponent<Inventory>();


        shop = player.GetComponent<Shop>();

    }

    private void OnDestroy()
    {
       
        switch (this.gameObject.name)
        {
            case "Grass(Clone)":
                inventory.inv[0]++;
                break;
            case "dirt(Clone)":
                inventory.inv[1]++;
                break;
            case "rock(Clone)":
                inventory.inv[2]++;
                break;
            case "iron(Clone)":
                inventory.inv[3]++;
                break;
            case "gold(Clone)":
                inventory.inv[4]++;
                break;
            case "diamond(Clone)":
                inventory.inv[5]++;
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
        if (_result < 9f)
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
        if (shop.miningSPeedBuff == 0)
        {
            yield return new WaitForSeconds(BreakTime);
        }
        else
        {
            yield return new WaitForSeconds(BreakTime - shop.miningSPeedBuff/10);
        }
        
        broke = held;
    }

    
}
