using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject BG;

    public Text QuestionText;
    public Text ScoreText;

    int totalQuestions = 0;
    public int score;

    public void StartQuiz()
    {
        Quizpanel.SetActive(true);
        totalQuestions = QnA.Count;
        BG.SetActive(false);    
        generateQuestion();
    }

    public void EndQuiz()
    {
        BG.SetActive(false);
    }


    void GameOver()
    {
        Quizpanel.SetActive(false);
        BG.SetActive(true);
        ScoreText.text = "YOUR SCORE IN PARK'S QUIZ: \n" + score + " / " + totalQuestions + " \n Press ESC and Step Away to leave this Quiz.";
    }


    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }


    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }

    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Question;

            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
