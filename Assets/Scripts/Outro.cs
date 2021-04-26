using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Outro : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text time;
    private TimeSpan timePlayed;
    void Start()
    {
        timePlayed = TimeSpan.FromSeconds(VariableControl.instance.time);
        time.text = timePlayed.ToString("mm':'ss'.'ff");
        score.text = VariableControl.instance.score + "/10";
    }

    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
