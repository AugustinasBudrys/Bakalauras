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
    public void Open()
    {
        gameObject.layer = 6;
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
    }

    public void Close()
    {
        gameObject.layer = 8;
        gameObject.GetComponent<SpriteRenderer>().sprite = close;
    }
}
