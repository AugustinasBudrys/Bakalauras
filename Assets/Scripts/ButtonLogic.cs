using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Used to define what action happens when an in game button gets pressed
public class ButtonLogic : MonoBehaviour
{
    private bool inRange;
    [SerializeField]
    private CharacterInteractions2D click;
    [SerializeField]
    private OpenDoor doors;
    [SerializeField]
    private Text text;
    private bool notCounting = true;
    private bool isNotEmpty = false;
    private bool isCorrect = false;
    [SerializeField]
    private int correctAmount;

    //Depending on the level checks for button changes and opens or closes doors depending on actions taken
    void FixedUpdate()
    {
        DoorControl();
        if(notCounting == false)
        {
            text.text = ""+click.clickAmount;
        }
    }

    //When in range to a button it can be pressed
    void OnTriggerEnter2D(Collider2D button)
    {
        if(button.gameObject.layer == 3)
        {
            inRange = true;
            setAction();
        }
    }

    //When player leaves button range it is registered so it can't be pressed
    void OnTriggerExit2D(Collider2D button)
    {
        if(button.gameObject.layer == 3)
        {
            inRange = false;
            setAction();
        }
    }

    // Sets the action which the button performs increments, decrements or confirms/cancels
    public void setAction()
    {
        if(inRange == true && gameObject.tag == "increment")
        {
            notCounting = false;
            click.setClickAction(true, notCounting);
        }else if(inRange == true && gameObject.tag == "decrement"){
            notCounting = false;
            click.setClickAction(false, notCounting);
        }else if(inRange == true)
        {
            notCounting = true;
            click.setClickAction(false, notCounting); 
        }
    }

    // Confirmation button when a designated area is filled used to confirm or cancel action
    public void confirmButton(bool isFilled, bool correct)
    {
        isCorrect = correct;
        if(isFilled == true)
        {
            isNotEmpty = true;
        }
        if(isFilled == false)
        {
            isNotEmpty = false;
        }
    }

    //Door control depending on the button action and button state opens or closes the doors 
    public void DoorControl()
    {
        if(click.buttonState == true && isNotEmpty == true && isCorrect == true)
        {
            doors.Open(true);
        }
        if(click.buttonState == true && isNotEmpty == true)
        {
            doors.Open(false);
        }else if(click.buttonState == false || isNotEmpty == false)
        {
            doors.Close();
        }
        if(click.clickAmount == correctAmount && notCounting == false)
        {
            doors.Open(true);
        }
        if(click.clickAmount > 0 && notCounting == false)
        {
            doors.Open(false);
        }else if(notCounting == false){
            doors.Close();
        }
    }
}
