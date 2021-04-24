using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInteractions2D : MonoBehaviour
{
    private bool isTriggered = false;
    private bool buttonTrigger = false;
    public bool buttonState = false;
    private bool switchButton = false;
    private bool isCorrect = false;
    private int score = 0;
    public string SceneName;

    private GameObject coin;
    private bool increment;
    public int clickAmount=0;
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
 
    void OnTriggerEnter2D(Collider2D door)
    {
        if(door.gameObject.layer == 6)
        {
            isTriggered = true;
            if(door.gameObject.tag == "correct")
            {
                isCorrect = true;
            }
        }else if(door.gameObject.layer == 9)
        {
            buttonTrigger = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
        buttonTrigger = false;
    }
    public void Enter(bool enter)
    {
        if(enter == true && isTriggered == true)
        {
            if(isCorrect == true)
            {
                score += 1;
            }
            Debug.Log(score);
            SceneManager.LoadScene(SceneName);
        }
    }

    public void Grab(bool interact)
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if(grabCheck.collider != null && grabCheck.collider.tag == "coin" || grabCheck.collider != null && grabCheck.collider.tag == "number")
        {
            if(interact == true && coin == null)
            {
                coin = grabCheck.collider.gameObject;
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
        }
        if(interact == false && coin != null){
                coin.transform.parent = null;
                coin.GetComponent<Rigidbody2D>().isKinematic = false;
                coin.GetComponent<Rigidbody2D>().simulated = true;
                coin = null;
        }
    }

    public void setClickAction(bool add, bool notCounting)
    {
        if(notCounting == true)
        {
            switchButton = true;
        }
        increment = add;
    }

    public void buttonAction(bool interact)
    {
        if(interact == true && buttonTrigger == true && switchButton == true && buttonState == false)
        {
            buttonState = true;
        }else if(interact == true && buttonTrigger == true && switchButton == true)
        {
            buttonState = false;
        }
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
