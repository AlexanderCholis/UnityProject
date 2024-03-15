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

    public static int score = 0;
    public static int highscore = 0;

    // Define keys for PlayerPrefs
    private const string HighScoreKey = "HighScore";

    // Variable to store the selected game mode
    //public static int highScore;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
   /* void Start()
    {
        scoreText.text = score.ToString() + " POINTS";

        if (PlayerPrefs.GetInt(HighScoreKey).ToString() != null)
            highscoreText.text = " HIGHSCORE: " + PlayerPrefs.GetInt(HighScoreKey).ToString();
        else
            highscoreText.text = " HIGHSCORE: " + highscore.ToString();
    }*/

    void Start()
    {
        // Load high score from PlayerPrefs
        highscore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateHighscoreText();

        // Update score text
        scoreText.text = score.ToString() + " POINTS";
    }

    void UpdateHighscoreText()
    {
        highscoreText.text = " HIGHSCORE: " + highscore.ToString();
    }

    public void AddPointEasyMode()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";

       /* if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HighScoreKey, highscore);
            PlayerPrefs.Save();
            UpdateHighscoreText();
        }*/
    }

    public void AddPointMediumMode()
    {
        score += 2;
        scoreText.text = score.ToString() + " POINTS";

       /* if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HighScoreKey, highscore);
            PlayerPrefs.Save();
            UpdateHighscoreText();
        }*/

    }

    public void AddPointHardMode()
    {
        score += 3;
        scoreText.text = score.ToString() + " POINTS";

       /* if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HighScoreKey, highscore);
            PlayerPrefs.Save();
            UpdateHighscoreText();
        }*/
    }

    // Ensure this GameObject persists across scenes
    void OnDestroy()
    {
        // Save the value when the object is destroyed
       // PlayerPrefs.SetInt(HighScoreKey, highscore);
       // PlayerPrefs.Save();

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt(HighScoreKey, highscore);
            PlayerPrefs.Save();
            UpdateHighscoreText();
        }

        if (highscore!=0)
        {
            Debug.Log("OnDestroy - Saved High Score: " + highscore);
        }
        else
        {
            Debug.Log("OnDestroy - No High Score Saved");
        }
    }
}
