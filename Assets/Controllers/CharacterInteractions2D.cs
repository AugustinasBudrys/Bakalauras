using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Used to define player interaction with other game objects
public class CharacterInteractions2D : MonoBehaviour
{
    private bool isTriggered = false;
    private bool buttonTrigger = false;
    public bool buttonState = false;
    private bool switchButton = false;
    private bool isCorrect = false;
    public string SceneName;

    private GameObject coin;
    private bool increment;
    public int clickAmount=0;
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
 
    void OnTriggerEnter2D(Collider2D door)
    {
        // checks if the player has come next to an open door
        if(door.gameObject.layer == 6)
        {
            isTriggered = true;
            // checks if the open door contains correct answer
            if(door.gameObject.tag == "correct")
            {
                isCorrect = true;
            }
        // checks if the game object is a button
        }else if(door.gameObject.layer == 9)
        {
            buttonTrigger = true;
        }
    }

    // Upon exiting the proximity of doors or buttons checks it as false
    void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
        buttonTrigger = false;
    }

    // Used for moving through doors from one stage to the next
    public void Enter(bool enter)
    {
        // if in the range of a door and next to it allows the player to go to next stage
        if(enter == true && isTriggered == true)
        {
            VariableControl.instance.time = TimerController.instance.elapsedTime;
            // if the answer is correct increments the score of the player
            if(isCorrect == true)
            {
                VariableControl.instance.score += 1;
                Debug.Log(VariableControl.instance.score);
            }
            SceneManager.LoadScene(SceneName);
        }
    }

    // Used in allowing player to pick up objects from the ground
    public void Grab(bool interact)
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        // checks if the grabbable object is among the list of defined ones and the player is near one
        if( grabCheck.collider != null && grabCheck.collider.tag == "coin" 
            || grabCheck.collider != null && grabCheck.collider.tag == "number" 
            || grabCheck.collider != null && grabCheck.collider.tag == "shape")
        {
            //if the player is trying to grab and item while holding one its gets set to character as a child object
            if(interact == true && coin == null)
            {
                coin = grabCheck.collider.gameObject;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
        // Used in dropping the coin on the ground if the hands are not empty
        if(interact == false && coin != null){
                coin.transform.parent = null;
                coin.GetComponent<Rigidbody2D>().isKinematic = false;
                coin.GetComponent<Rigidbody2D>().simulated = true;
                coin = null;
        }
    }

    // Changes the button state whether its used for counting or confirming
    public void setClickAction(bool add, bool notCounting)
    {
        if(notCounting == true)
        {
            switchButton = true;
        }
        increment = add;
    }

    // Used in deciding if the button was clicked for confirmation button or counting
    public void buttonAction(bool interact)
    {
        // changes if the button has been clicked and is being used for confirmation
        if(interact == true && buttonTrigger == true && switchButton == true && buttonState == false)
        {
            buttonState = true;
        }else if(interact == true && buttonTrigger == true && switchButton == true)
        {
            buttonState = false;
        }
        // checks if the button is used for counting and counts button clicks
        if(interact == true && buttonTrigger == true && switchButton == false)
        {
            if(increment == true)
            {
                clickAmount += 1;
            }else if(clickAmount == 0)
            {
                clickAmount = 0;
            }else{
                clickAmount -= 1;
            }
        }
    }
}
