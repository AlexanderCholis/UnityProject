using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            //score += 1;
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

    public void GameOver() 
    {
        ScoreText.text = "YOUR SCORE IN PARKING'S QUIZ: \n" + Score + " \n Step Away to end the Quiz or Press Exit to go in the center of the city";
    }


}