using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;

    public Text QuestionTxt;

    private void Start()
    {
        generateQuestion();
    }

    private void correct()
    {
        QnA.RemoveAt(currentQuestion);

        generateQuestion();
    }



    void SetAnswers()
    {
        for(int i = 0, i< options.Length, i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;

        SetAnswers();

    }

}
