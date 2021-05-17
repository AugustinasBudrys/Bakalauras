using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main Menu display
public class MainMenu : MonoBehaviour
{
    // Initializes the games first level
    public void PlayGame()
    {
        VariableControl.instance.score = 0;
        VariableControl.instance.time = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Closes the application
    public void QuitGame()
    {
        Application.Quit();
    }
}
