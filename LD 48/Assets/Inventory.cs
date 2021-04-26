using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int[] inv;

    public Text invTxt;
    void Awake()
    {
        inv = new int[6] {0,0,0,0,0,0};

        invTxt.enabled = false;
    }

   
    void Update()
    {
        invTxt.text = String.Format("Grass: {0} Dirt: {1} Stone: {2} Iron: {3} Gold: {4} Diamond: {5}", inv[0], inv[1],
            inv[2], inv[3], inv[4], inv[5]);

        if (Input.GetKeyDown(KeyCode.E))
        {
            invTxt.enabled = !invTxt.enabled;
        }
    }
    
    
}
