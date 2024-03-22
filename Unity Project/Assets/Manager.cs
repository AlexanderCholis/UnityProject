using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;

public class Manager : MonoBehaviour
{
    public GameObject[] Levels;

    public Text ScoreText;

    int currentLevel;

    public int Score;

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

    public void correctAnswer()
    {
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        if (selectedGameMode == "EASY" && currentLevel < 4)
        {
            Levels[currentLevel].SetActive(false);
            Score++;
            ScoreManager.instance.AddPointEasyMode();
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "EASY" && currentLevel == 4)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver();
            Levels[11].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel < 7)
        {
            Levels[currentLevel].SetActive(false);
            Score++;
            ScoreManager.instance.AddPointEasyMode();
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel == 7)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver();
            Levels[11].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "HARD" && currentLevel < 10)
        {
            Levels[currentLevel].SetActive(false);
            Score++;
            ScoreManager.instance.AddPointEasyMode();
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "HARD" && currentLevel == 10)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            //GameOver();
            Levels[11].SetActive(true); // Activate Level 11 to display score
        }
    }

    public void wrongAnswer()
    {
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        if (selectedGameMode == "EASY" && currentLevel < 4)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "EASY" && currentLevel == 4)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver();
            Levels[11].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel < 7)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "MEDIUM" && currentLevel == 7)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            GameOver();
            Levels[11].SetActive(true); // Activate Level 11 to display score
        }
        else if (selectedGameMode == "HARD" && currentLevel < 10)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
        else if (selectedGameMode == "HARD" && currentLevel == 10)
        {
            Levels[currentLevel].SetActive(false); // Deactivate last level
            //GameOver();
            Levels[11].SetActive(true); // Activate Level 11 to display score
        }
    }

    public void StartQuiz()
    {

        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("Gamemode: " + selectedGameMode);

        // depending on the mode show and hide the nessesary questions
        if (selectedGameMode == "EASY")
        {
            // show easy mode questions, hide medium and hard mode questions

            // Activate the first level
            Levels[0].SetActive(false); //intro

            Levels[1].SetActive(true);
            Levels[2].SetActive(true);
            Levels[3].SetActive(true);
            Levels[4].SetActive(true);
            Levels[11].SetActive(false); //score


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
            Levels[7].SetActive(true);
            Levels[11].SetActive(false);


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
            Levels[10].SetActive(true);
            Levels[11].SetActive(false);


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

    public void GameOver()
    {

        string localizedScoreText = score1LocalizationString.GetLocalizedString() + " " + Score;

        string localizedContinueText = score2LocalizationString.GetLocalizedString();

        ScoreText.text = localizedScoreText + "\n" + localizedContinueText;

        //ScoreText.text = "YOUR SCORE IN PARKING'S QUIZ: \n" + Score + " \n Step Away to end the Quiz and continue to level 3 in the main park";
        //for Medium Level: ScoreText.text = "YOUR SCORE IN PARKING'S QUIZ: \n" + Score + "/6" + " \n Step Away to end the Quiz and continue to level 3 in the main park";
    }


}