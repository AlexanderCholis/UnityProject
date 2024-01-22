using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // to change scenes

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2);

    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME!");

        // exit play mode (when in unity editor)
        UnityEditor.EditorApplication.isPlaying = false;

        // exit game (when game is outside the unity editor)
        Application.Quit();
    }




}
