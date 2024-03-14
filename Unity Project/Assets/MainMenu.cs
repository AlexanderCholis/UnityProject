using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // to change scenes
using TMPro;
using System;


public class MainMenu : MonoBehaviour
{
    // Define keys for PlayerPrefs
    private const string GameModeKey = "GameMode";

    // Variable to store the selected game mode
    public static string selectedGameMode;



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

    public void EasyMode()
    {

        // Set the value of lastClickedButton
        selectedGameMode = "EASY";

        // Save the value to PlayerPrefs
        PlayerPrefs.SetString(GameModeKey, selectedGameMode);
        PlayerPrefs.Save();

        SceneManager.LoadScene(2);       
    }

    public void MediumMode()
    {
        selectedGameMode = "MEDIUM";
        PlayerPrefs.SetString(GameModeKey, selectedGameMode);
        PlayerPrefs.Save();

        SceneManager.LoadScene(2);
    }

    public void HardMode()
    {
        selectedGameMode = "HARD";
        PlayerPrefs.SetString(GameModeKey, selectedGameMode);
        PlayerPrefs.Save();

        SceneManager.LoadScene(2);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // Retrieve the saved game mode when the GameObject is created
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("Awake - Retrieved Game Mode: " + selectedGameMode);
    }


    // Ensure this GameObject persists across scenes
    void OnDestroy()
    {
        // Save the value when the object is destroyed
        PlayerPrefs.SetString(GameModeKey, selectedGameMode);
        PlayerPrefs.Save();

        if (!string.IsNullOrEmpty(selectedGameMode))
        {
            Debug.Log("OnDestroy - Saved Game Mode: " + selectedGameMode);
        }
        else
        {
            Debug.Log("OnDestroy - No Game Mode Saved");
        }
    }
}

