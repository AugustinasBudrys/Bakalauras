using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class responsible for changing the door state from open to closed and vice versa
public class OpenDoor : MonoBehaviour
{
    private SpriteRenderer spriter;
    [SerializeField]
    private Sprite open;
    [SerializeField]
    private Sprite close;
    // Opens the door changes its sprite and if its correct indicates it
    public void Open(bool isCorrect)
    {
        gameObject.layer = 6;
        if(isCorrect == true)
        {
            gameObject.tag = "correct";
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
    }

    // Closes the door once a completion action is reversed and changes the sprite
    public void Close()
    {
        gameObject.layer = 8;
        gameObject.tag = "Untagged";
        gameObject.GetComponent<SpriteRenderer>().sprite = close;
    }
}
