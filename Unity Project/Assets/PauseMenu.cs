using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Canvas canvas;

    public GameObject imagePanel; // Reference to the GameObject containing the Image component

    public Sprite easyImage;
    public Sprite mediumImage;
    public Sprite hardImage;


    // Variable to store the last clicked button
    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuUI.SetActive(false);
        canvas.enabled = false;
        Time.timeScale = 1f; // back to normal
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuUI.SetActive(true);
        canvas.enabled = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //Debug.Log("Loading Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");

        // stop the play mode (when in unity editor)
        UnityEditor.EditorApplication.isPlaying = false;

        // exit the game when running outside the unity editor
        Application.Quit();
    }

    public void ShowTownMap()
    {

        selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        Image imageComponent = null;

        // Check if imagePanel exists
        if (imagePanel != null)
        {
            // Find the Canvas component within the imagePanel
            Canvas canvas = imagePanel.GetComponentInChildren<Canvas>(true);

            // Check if the Canvas component exists
            if (canvas != null)
            {
                // Find the Image component within the Canvas
                imageComponent = canvas.GetComponentInChildren<Image>(true);
            }
            else
            {
                Debug.LogError("Canvas component not found within children of imagePanel.");
            }
        }
        else
        {
            Debug.LogError("imagePanel GameObject not assigned.");
        }


        if (imageComponent != null)
        {
            switch (selectedGameMode)
            {
                case "EASY":
                    imageComponent.sprite = easyImage;
                    break;
                case "MEDIUM":
                    imageComponent.sprite = mediumImage;
                    break;
                case "HARD":
                    imageComponent.sprite = hardImage;
                    break;
                default:
                    Debug.LogError("Invalid game mode: " + selectedGameMode);
                    break;
            }
            imagePanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Image component not found within children of imagePanel.");
        }
    }

    public void Back()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;  

        imagePanel.SetActive(false); // Activate the image panel GameObject
        pauseMenuUI.SetActive(true);

    }
}
