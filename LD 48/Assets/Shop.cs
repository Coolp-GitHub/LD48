using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Shop : MonoBehaviour
{
    public Canvas shop;
    public Button sellAll;
    public Button speedUpgrade;
    public Button jumpUpgrade;
    public Button miningSpeedUpgrade;
    public Inventory inv;
    public int coins;



    public Text speed;
    public Text Miningspeed;
    public Text Jump;
    public Text Coinstxt;
    
    public int speedBuff;
    public int jumpBuff;
    public int miningSPeedBuff;


    public int speedPrice = 10;
    public int jumpPrice = 10;
    public int miningPrice = 10;

    private bool canbuy = true;
    void Start()
    {
        shop.enabled = false;
       
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shop.enabled = !shop.enabled;
        }
    
        sellAll.onClick.AddListener(UpdateCoins);

        if (canbuy)
        {
            speedUpgrade.onClick.AddListener(speedUp);
            jumpUpgrade.onClick.AddListener(jumpUp);
            miningSpeedUpgrade.onClick.AddListener(miningSpeedUp);
        }

        Coinstxt.text ="Coins Owned: " + coins.ToString();




        speed.text = String.Format("Speed upgrade price: {0}",speedPrice);
        Jump.text = String.Format(" Jump Upgrade price: {0}",jumpPrice);
        Miningspeed.text = String.Format("Mining Upgrade price: {0}",miningPrice);
        
        
        
        
    }

    private void UpdateCoins()
    {
        for (int i = 0; i < inv.inv.Length; i++)
        {
            int price = i switch
            {
                0 => 1,
                1 => 1,
                2 => 1,
                3 => 5,
                4 => 15,
                5 => 25,
                _ => 0
            };
            
            
            coins += inv.inv[i] * price;
            inv.inv[i] = 0;

        }
    }


    private void speedUp()
    {
        if (coins > speedPrice)
        {
            speed.text = String.Format("price: {0}", speedPrice);
            speedBuff += 1;
            coins -= speedPrice;
            speedPrice += speedPrice / 2;
            canbuy = false;
            StartCoroutine(BuyCooldown());
        }

    }
    private void jumpUp()
    {
        if (coins > jumpPrice)
        {
            Jump.text = String.Format("price: {0}", jumpPrice);
            coins -= jumpPrice;
            jumpBuff += 1;
            jumpPrice += jumpPrice / 2;
            canbuy = false;
            StartCoroutine(BuyCooldown());

        }
        

    }
    private void miningSpeedUp()
    {
        if (coins > miningPrice)
        {
            Miningspeed.text = String.Format("price: {0}", miningPrice);
            coins -= miningPrice;
            miningSPeedBuff += 1;
            miningPrice += miningPrice / 2;
            canbuy = false;
            StartCoroutine(BuyCooldown());

        }

    }

    IEnumerator BuyCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        canbuy = true;

    }
}
