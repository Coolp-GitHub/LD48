using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    [SerializeField] private float horMove;
    private bool _jump = false;
    [SerializeField] private float runSpeed;
    public Shop shop;


    private void Awake()
    {
        shop = gameObject.GetComponent<Shop>();
    }


    void Update()
    {
        if (shop.speedBuff == 0)
        {
            horMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        else
        {
            horMove = Input.GetAxisRaw("Horizontal") * runSpeed * shop.speedBuff;
        }



        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
        }



           
    }

    private void FixedUpdate()
    {
        controller.Move(horMove, false, _jump);
        _jump = false;
    }
}