using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public CharacterInteractions2D interactions2D;

    float horizontalMove = 0f;
    bool jump = false;
    bool enter = false;
    bool interact = false;
    public float runSpeed = 40f;
    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

       if(Input.GetButtonDown("Jump"))
       {
           jump = true;
       }

       if(Input.GetButtonDown("Enter"))
       {
           enter = true;
       }

        if(Input.GetButtonDown("Interact"))
       {
           interact=true;
       }else if(Input.GetButtonUp("Interact"))
       {
           interact=false;
       }
    }

    void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        interactions2D.Enter(enter);
        enter = false;
        interactions2D.Grab(interact);
    }
}
