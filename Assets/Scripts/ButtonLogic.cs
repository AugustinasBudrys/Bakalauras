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
            click.setClickAction(true);
            notCounting = false;
        }else if(inRange == true && gameObject.tag == "decrement"){
            click.setClickAction(false);
            notCounting = false;
        }else if(inRange == true)
        {
            notCounting = true;
        }
    }

    public void DoorControl()
    {
        if(click.clickAmount > 0)
        {
            doors.Open();
        }else{
            doors.Close();
        }
    }
}
