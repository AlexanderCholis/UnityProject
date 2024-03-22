using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;

public class LevelCompletion : MonoBehaviour
{
    public TextMeshProUGUI completionText; // Reference to the text component to display completion message
    public string easyCompletionText = "Congratulations! You completed the Easy level!";
    public string mediumCompletionText = "Congratulations! You completed the Medium level!";
    public string hardCompletionText = "Congratulations! You completed the Hard level!";

    public static string selectedGameMode;
    private const string GameModeKey = "GameMode";

    // Start is called before the first frame update
    void Start()
    {
        // Disable the completion text initially
        completionText.gameObject.SetActive(false);
    }

    // Method to display completion message based on the level completed
    public void ShowCompletionText()
    {
        // Get the selected game mode
        string selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        // Get the current score
        int score = ScoreManager.score;

        // Choose the completion message based on the score and selected game mode
        string message = "";

        if (selectedGameMode == "EASY" && score >= 2)
        {
            message = easyCompletionText;
        }
        else if (selectedGameMode == "MEDIUM" && score >= 25)
        {
            message = mediumCompletionText;
        }
        else if (selectedGameMode == "HARD" && score >= 40)
        {
            message = hardCompletionText;
        }

        // Display the completion message
        completionText.text = message;
        completionText.gameObject.SetActive(true);
    }
}
