using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject[] Levels; // Array of UI elements representing different levels
    private int currentLevel = 0; // Variable to keep track of the current level
    public GameObject Canvas2; // Reference to the canvas GameObject

    private void Start()
    {
        // Deactivate all level UI elements except the first one when the game starts
        for (int i = 1; i < Levels.Length; i++)
        {
            Levels[i].SetActive(false);
        }

        // Deactivate the canvas when the game starts
        Canvas2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your main character has the "Player" tag
        {
            // Show the UI element corresponding to the current level
            Levels[currentLevel].SetActive(true);

            // Activate the canvas
            Canvas2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your main character has the "Player" tag
        {
            // Hide all level UI elements when the player exits the trigger
            foreach (GameObject uiElement in Levels)
            {
                uiElement.SetActive(false);
            }
            // Deactivate the canvas when the player exits the trigger
            Canvas2.SetActive(false);
        }
    }

    public void SetCurrentLevel(int level)
    {
        // Update the current level
        currentLevel = level;
        // Hide all level UI elements except the one corresponding to the current level
        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].SetActive(i == currentLevel);
        }
    }
}