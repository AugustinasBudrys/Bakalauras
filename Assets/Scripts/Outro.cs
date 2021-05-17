using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Used to in display of the outro screen containing the score
public class Outro : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text time;
    private TimeSpan timePlayed;

    // Once the score screen loads it initializes variables to be displayed
    void Start()
    {
        timePlayed = TimeSpan.FromSeconds(VariableControl.instance.time);
        time.text = timePlayed.ToString("mm':'ss'.'ff");
        score.text = VariableControl.instance.score + "/5";
    }

    // Used once the menu button is pressed to load the menu
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
