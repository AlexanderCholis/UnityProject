using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using TMPro;

public class Manager2 : MonoBehaviour
{
    public GameObject[] Levels;

    public Text ScoreText;

    int currentLevel;

    public int Score;

    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    public LocalizedString finishEasy;

    //Variable to store the last clicked button
    public static string selectedGameMode;
    
    private const string GameModeKey = "GameMode";

    public LocalizedString score1LocalizationString;

    public LocalizedString score2LocalizationString;

    /*
    public void correctAnswer()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);
            Score++;
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
    }

    public void wrongAnswer()
    {
        if (currentLevel + 1 != Levels.Length)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
    }
    */

    public void correctAnswer2()
    {
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        if (selectedGameMode == "EASY" && currentLevel < 3)
        {
            Levels[currentLevel].SetActive(false);
            Score++;
            ScoreManager.instance.AddPointEasyMode();
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "EASY" && currentLevel == 3)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver2();
            Levels[10].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel < 6)
        {
            Levels[currentLevel].SetActive(false);
            Score++;
            ScoreManager.instance.AddPointEasyMode();
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel == 6)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver2(); 
            Levels[10].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "HARD" && currentLevel < 9)
        {
            Levels[currentLevel].SetActive(false);
            Score++;
            ScoreManager.instance.AddPointEasyMode();
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "HARD" && currentLevel == 9)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            //GameOver2();
            Levels[10].SetActive(true); // Activate Level 11 to display score
        }
    }

    public void wrongAnswer2()
    {
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        if (selectedGameMode == "EASY" && currentLevel < 3)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "EASY" && currentLevel == 3)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver2();
            Levels[10].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel < 6)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel == 6)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver2(); 
            Levels[10].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "HARD" && currentLevel < 9)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "HARD" && currentLevel == 9)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            //GameOver2();
            Levels[10].SetActive(true); // Activate Level 11 to display score
        }
    }

    public void StartQuiz2()
    {
        
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("Gamemode: " +  selectedGameMode);

        // depending on the mode show and hide the nessesary questions
        if (selectedGameMode == "EASY")
        {
            // show easy mode questions, hide medium and hard mode questions

            // Activate the first level
            Levels[0].SetActive(false); //intro

            Levels[1].SetActive(true);
            Levels[2].SetActive(true);
            Levels[3].SetActive(true);
            Levels[10].SetActive(false); //score


            // Deactivate the intro page or any other UI elements
            //gameObject.SetActive(false); // Assuming the Manager is attached to the intro page GameObject

            // Initialize score and currentLevel
            Score = 0;
            currentLevel = 0;

        }

        if (selectedGameMode == "MEDIUM")
        {
            // show medium mode questions, hide easy and hard mode questions

            // Activate the first level
            Levels[0].SetActive(false); //intro

            Levels[1].SetActive(true);
            Levels[2].SetActive(true);
            Levels[3].SetActive(true);
            Levels[4].SetActive(true);
            Levels[5].SetActive(true);
            Levels[6].SetActive(true);
            Levels[10].SetActive(false);


            // Deactivate the intro page or any other UI elements
            //gameObject.SetActive(false); // Assuming the Manager is attached to the intro page GameObject

            // Initialize score and currentLevel
            Score = 0;
            currentLevel = 0;
        }

        if (selectedGameMode == "HARD")
        {
            // show hard mode questions, hide easy and medium mode questions

            // Activate the first level
            Levels[0].SetActive(false); //intro

            Levels[1].SetActive(true);
            Levels[2].SetActive(true);
            Levels[3].SetActive(true);
            Levels[4].SetActive(true);
            Levels[5].SetActive(true);
            Levels[6].SetActive(true);
            Levels[7].SetActive(true);
            Levels[8].SetActive(true);
            Levels[9].SetActive(true);
            Levels[10].SetActive(false);


            // Deactivate the intro page or any other UI elements
            //gameObject.SetActive(false); // Assuming the Manager is attached to the intro page GameObject

            // Initialize score and currentLevel
            Score = 0;
            currentLevel = 0;
        }
        
        /*
        // Activate the first level
        Levels[0].SetActive(false);

        Levels[1].SetActive(true);
        Levels[2].SetActive(true);
        Levels[3].SetActive(true);
        Levels[4].SetActive(true);
        Levels[5].SetActive(true);
        Levels[6].SetActive(true);
        Levels[7].SetActive(true);
        Levels[8].SetActive(true);
        Levels[9].SetActive(true);
        Levels[10].SetActive(true);
        Levels[11].SetActive(false);


        // Deactivate the intro page or any other UI elements
        //gameObject.SetActive(false); // Assuming the Manager is attached to the intro page GameObject

        // Initialize score and currentLevel
        Score = 0;
        currentLevel = 0;
        */
    }

    public void GameOver2()
    {

        string localizedScoreText = score1LocalizationString.GetLocalizedString() + " " + Score;

        string localizedContinueText = score2LocalizationString.GetLocalizedString();

        ScoreText.text = localizedScoreText + "\n" + localizedContinueText;

        if (selectedGameMode == "EASY")
        {
            dialogueText = dialogueCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>();

            if (dialogueText == null)
            {
                Debug.LogError("Text component not found in the Canvas!");
            }
            else
            {
                dialogueCanvas.enabled = false;
            }

            string localizedMessage = finishEasy.GetLocalizedString();
            dialogueText.text = localizedMessage;

        }
    }
}