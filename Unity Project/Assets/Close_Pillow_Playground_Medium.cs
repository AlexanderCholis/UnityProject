using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;

public class Close_Pillow_Playground_Medium : MonoBehaviour
{
    public LocalizedString ClosePillowMedium;
    //public string npcMessage = "You found the pillow, keep going!";
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    public GameObject BlackPillow;

    public TextMeshProUGUI scoreText;
    private string[] parts; // Define the parts array here
    string numberPart;

    void Start()
    {
        // Assuming the Text component is a child of the Canvas
        //dialogueText = dialogueCanvas.GetComponentInChildren<Text>();
        dialogueText = dialogueCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>();

        if (dialogueText == null)
        {
            Debug.LogError("Text component not found in the Canvas!");
        }
        else
        {
            dialogueCanvas.enabled = false;
        }
    }

    IEnumerator HideObjectDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (BlackPillow != null)
        {
            BlackPillow.SetActive(false);
        }
        else
        {
            Debug.LogError("BlackPillow GameObject is not assigned.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null)
            {
                //dialogueText.text = npcMessage;

                string localizedMessage = ClosePillowMedium.GetLocalizedString();
                dialogueText.text = localizedMessage;

                ScoreManager.instance.AddPointEasyMode();
                StartCoroutine(HideObjectDelayed(3f)); // Delay for 3 seconds
            }
            else
            {
                Debug.LogError("Text component not found in the Canvas!");
            }

            dialogueCanvas.enabled = true;
        }
        else
        {
            Debug.LogError("Error on trigger enter");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueCanvas.enabled = false;
        }
        else
        {
            Debug.LogError("Error on trigger exit");
        }
    }

    // Check the score and display a message when it reaches 4
    /*void Update()
    {
        if (scoreText != null)
        {
            // Split the score text and store the parts in the array
            parts = scoreText.text.Split(' ');

            if (parts.Length > 0)
            {
                numberPart = parts[0]; // Get the first part
                //print("Score Number: " + numberPart);
            }
            else
            {
                Debug.LogError("Invalid points string format!");
            }
        }
        else
        {
            Debug.LogError("Score text is not assigned!");
        }

        if (numberPart == "4")
        {
            StartCoroutine(ShowDialogueAfterDelay(2f));
        }
    }


    IEnumerator ShowDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        dialogueText.text = "Congratulations! You can now continue to your next mission" +
            "\n located in the parking garage!";
        dialogueCanvas.enabled = true;

        yield return new WaitForSeconds(4f); // Wait for 3 seconds

        dialogueCanvas.enabled = false; // Hide the dialogue canvas
    }*/
}
