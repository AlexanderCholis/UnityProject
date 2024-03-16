using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HiddenObjectCheckPlaygroundHard : MonoBehaviour
{
    public GameObject[] objectsToCheck; // Array of objects to check if they are hidden
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;
    public string messageText = "All objects are hidden playground hard!"; // Message to display
    public float messageDuration = 4f; // Duration in seconds before hiding the message


    // Variable to store the last clicked button
    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

    void Start()
    {
        dialogueText = dialogueCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        if (dialogueText == null)
        {
            Debug.LogError("Text component not found in the Canvas!");
        }
        else
        {
            dialogueCanvas.enabled = false;
        }

        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
    }

    void Update()
    {
        if (selectedGameMode == "HARD")
        {
            // Check if all objects are hidden
            bool allHidden = true;
            foreach (GameObject obj in objectsToCheck)
            {
                if (obj.activeSelf)
                {
                    allHidden = false;
                    break; // Exit the loop early if any object is not hidden
                }
            }

            // If all objects are hidden, show the message
            if (allHidden && Close_Player_In_Villa.mission == false && Close_NPC_Playground.mission)
            {
                //StartCoroutine(ShowDialogueAfterDelay(2f));
                ShowMessage();
            }
        }
    }

    IEnumerator ShowDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        dialogueText.text = messageText;
        dialogueCanvas.enabled = true;

        yield return new WaitForSeconds(4f); // Wait for 3 seconds

        dialogueCanvas.enabled = false; // Hide the dialogue canvas
    }


    void ShowMessage()
    {
        // Show the message canvas and set the text
        if (dialogueText != null)
        {
            dialogueText.text = messageText;
        }
        else
        {
            Debug.LogError("Text component not found in the Canvas!");
        }

        dialogueCanvas.enabled = true;

        // Start coroutine to hide the message after messageDuration seconds
       // StartCoroutine(HideMessageAfterDelay(messageDuration));
    }

    /*
    IEnumerator HideMessageAfterDelay(float delay)
    {
        // Wait for delay seconds
        yield return new WaitForSeconds(delay);

        // Hide the message canvas
        dialogueCanvas.enabled = false;
    }*/
}