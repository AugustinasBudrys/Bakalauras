using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Used within the timer in the game
public class TimerController : MonoBehaviour
{
    public static TimerController instance;
    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    public float elapsedTime;

    // Make the timer accesible to other game objects
    private void Awake()
    {
        instance = this;
    }

    // Initialize timer state
    private void Start()
    {
        timeCounter.text = "Time: 00:00:00";
        timerGoing = false;
    }

    // Used to initiate timer between stages
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = VariableControl.instance.time;

        StartCoroutine(UpdateTimer());
    }
    
    // Calculates the time to be displayed on screen
    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
