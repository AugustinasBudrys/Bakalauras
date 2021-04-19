using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInteractions2D : MonoBehaviour
{
    private bool isTriggered = false;
    private int score = 0;
    public string SceneName;

    private GameObject coin;
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
 
    void OnTriggerEnter2D(Collider2D door)
    {
        if(door.gameObject.layer == 6)
        {
            isTriggered = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }
    public void Enter(bool enter)
    {
        if(enter == true && isTriggered == true)
        {
            SceneManager.LoadScene(SceneName);
            score += 1;
        }
    }

    public void Grab(bool interact)
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if(grabCheck.collider != null && grabCheck.collider.tag == "coin")
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
}
