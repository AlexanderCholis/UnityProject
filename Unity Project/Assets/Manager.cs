using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject[] Levels;

    public Text ScoreText;

    int currentLevel;

    public int Score;

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

    public void StartQuiz()
    {
        // Activate the first level
        Levels[0].SetActive(false);

        Levels[1].SetActive(true);
        Levels[2].SetActive(true);
        Levels[3].SetActive(true);
        Levels[4].SetActive(true);
        Levels[5].SetActive(true);
        Levels[5].SetActive(true);
        Levels[6].SetActive(true);
        Levels[7].SetActive(true);
        Levels[8].SetActive(true);
        Levels[9].SetActive(true);
        Levels[10].SetActive(true);


        // Deactivate the intro page or any other UI elements
        //gameObject.SetActive(false); // Assuming the Manager is attached to the intro page GameObject

        // Initialize score and currentLevel
        Score = 0;
        currentLevel = 0;
    }

    public void GameOver() 
    {
        ScoreText.text = "YOUR SCORE IN PARKING'S QUIZ: \n" + Score + " \n Step Away to end the Quiz and continue to level 3 in the main park";
        //for Medium Level: ScoreText.text = "YOUR SCORE IN PARKING'S QUIZ: \n" + Score + "/6" + " \n Step Away to end the Quiz and continue to level 3 in the main park";
    }


}