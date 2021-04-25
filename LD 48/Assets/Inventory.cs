using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] inventory;
    void Start()
    {
        inventory = new int[5] {0,0,0,0,0};
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(inventory[0]);
        }
    }
}
