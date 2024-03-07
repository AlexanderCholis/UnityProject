using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanStandingParkScript : MonoBehaviour
{

    public QuizManager quizManager; // Reference to the QuizManager script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming the quizManager has a method to start the quiz
            quizManager.StartQuiz();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quizManager.EndQuiz();
        }
    }

}
