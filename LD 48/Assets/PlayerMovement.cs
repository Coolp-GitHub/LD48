using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    [SerializeField] private float horMove;
    private bool _jump = false;
    [SerializeField] private float runSpeed;
      

        


    void Update()
    {

        horMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                
        
        

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