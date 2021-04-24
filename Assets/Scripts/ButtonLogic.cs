using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void FixedUpdate()
    {
        DoorControl();
        if(notCounting == false)
        {
            text.text = ""+click.clickAmount;
        }
    }
    void OnTriggerEnter2D(Collider2D button)
    {
        if(button.gameObject.layer == 3)
        {
            inRange = true;
            setAction();
        }
    }

    void OnTriggerExit2D(Collider2D button)
    {
        if(button.gameObject.layer == 3)
        {
            inRange = false;
            setAction();
        }
    }
    // Start is called before the first frame update
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

    public void confirmButton(bool isFilled)
    {
        if(isFilled == true)
        {
            isNotEmpty = true;
        }
        if(isFilled == false)
        {
            isNotEmpty = false;
        }
    }
    public void DoorControl()
    {
        if(click.buttonState == true && isNotEmpty == true)
        {
            doors.Open(false);
        }else if(click.buttonState == false || isNotEmpty == false)
        {
            doors.Close();
        }
        if(click.clickAmount > 0 && notCounting == false)
        {
            doors.Open(false);
        }else if(notCounting == false){
            doors.Close();
        }
    }
}
