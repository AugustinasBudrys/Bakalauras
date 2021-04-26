using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int Count = 0;
    [SerializeField]
    private OpenDoor doors;
    [SerializeField]
    private ButtonLogic button;
    [SerializeField]
    private int correctAmount = 3;
    private bool isNumber = false;
    public bool isCorrect = false;
    void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.gameObject.tag == "coin")
        {
            Count += 1;
            DoorControl();
            Debug.Log(Count);
        }
        if(coin.gameObject.tag == "number")
        {
            isNumber = true;
            button.confirmButton(isNumber);
        }
        if(coin.gameObject.tag == "shape")
        {
            Count += 1;
            if(coin.gameObject.layer == 11)
            {
                isCorrect = true;
            }
            DoorControl();
        }
    }

    void OnTriggerExit2D(Collider2D coin)
    {
        if(coin.gameObject.tag == "coin")
        {
            Count -= 1;
            DoorControl();
            Debug.Log(Count);
        }
        if(coin.gameObject.tag == "number")
        {
            isNumber = false;
            button.confirmButton(isNumber);
        }
        if(coin.gameObject.tag == "shape")
        {
            Count -= 1;
            DoorControl();
            if(coin.gameObject.layer == 11)
            {
                isCorrect = false;
            }
        }
    }

    void DoorControl()
    {   if(Count == correctAmount || isCorrect == true)
        {
            doors.Open(true);
        }else if(Count > 0)
        {
            doors.Open(false);
        }else{
            doors.Close();
        }
    }
}
