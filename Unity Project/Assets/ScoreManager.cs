using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public int score = 0;
    public int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = " HIGHSCORE: " + highscore.ToString();
    }

    public void AddPointEasyMode()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }
}
