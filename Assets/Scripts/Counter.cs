using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int Count = 0;
    [SerializeField]
    private OpenDoor doors;
    void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.gameObject.tag == "coin")
        {
            Count += 1;
            DoorControl();
            Debug.Log(Count);
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
    }

    void DoorControl()
    {
        if(Count > 0)
        {
            doors.Open();
        }else{
            doors.Close();
        }
    }
}
