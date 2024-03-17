using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanStandingParkScript : MonoBehaviour
{

    public QuizManager quizManager; 
    public QuizManager quizManager2;
    public QuizManager quizManager3;

    public static string selectedGameMode;
    private const string GameModeKey = "GameMode";

    void Start()
    {
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("GameMode:" + selectedGameMode);
    }

    private void OnTriggerEnter(Collider other)

    {
        if (selectedGameMode == "EASY" && other.CompareTag("Player"))
        {
                quizManager.StartQuiz();
        }
        else if (selectedGameMode == "MEDIUM" && other.CompareTag("Player"))
            {
                quizManager2.StartQuiz();
            }
        else if (selectedGameMode == "HARD" && other.CompareTag("Player"))
        {
            quizManager2.StartQuiz();
        }

    }


    private void OnTriggerExit(Collider other)
    {

        if (selectedGameMode == "EASY" && other.CompareTag("Player"))
        {
            quizManager.EndQuiz();
        }
        else if (selectedGameMode == "MEDIUM" && other.CompareTag("Player"))
        {
            quizManager2.EndQuiz();
        }
        else if (selectedGameMode == "HARD" && other.CompareTag("Player"))
        {
            quizManager3.EndQuiz();
        }
    }
}
