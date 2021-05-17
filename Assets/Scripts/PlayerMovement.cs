using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used to register player actions
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public CharacterInteractions2D interactions2D;

    float horizontalMove = 0f;
    bool jump = false;
    bool enter = false;
    bool interact = false;
    public float runSpeed = 40f;
    bool begin = true;
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
    // Fixed update is called 50 times per frame to check for movement calls
    void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
        interactions2D.Enter(enter);
        interactions2D.Grab(interact);
        interactions2D.buttonAction(enter);
        enter = false;
        if(begin == true)
        {
            BeginGame();
            begin = false;
        }
    }

    // Calls timer from the timer controller to start the timer upon game start
    void BeginGame()
    {
       TimerController.instance.BeginTimer();
    }
}
