using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject[] Levels;

    int currentLevel;

    public void correctAnswer()
    {
        if (currentLevel < Levels.Length - 1)
        {
            Levels[currentLevel].SetActive(false);
            currentLevel++;
            Levels[currentLevel].SetActive(true);
        }
    }
}
