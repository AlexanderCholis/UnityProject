using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour
{
    // Method to handle exit button click
    public void ExitQuiz()
    {
        // Exit the quiz by loading the main menu scene
        SceneManager.LoadScene(2);
    }
}
