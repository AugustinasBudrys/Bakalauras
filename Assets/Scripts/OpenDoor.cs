using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private SpriteRenderer spriter;
    [SerializeField]
    private Sprite open;
    [SerializeField]
    private Sprite close;
    public void Open(bool isCorrect)
    {
        gameObject.layer = 6;
        if(isCorrect == true)
        {
            gameObject.tag = "correct";
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
    }

    public void Close()
    {
        gameObject.layer = 8;
        gameObject.tag = "untagged";
        gameObject.GetComponent<SpriteRenderer>().sprite = close;
    }
}
