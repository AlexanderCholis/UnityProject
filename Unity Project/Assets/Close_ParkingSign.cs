using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_ParkingSign : MonoBehaviour
{
    public string npcMessage = "ΗΙΝΤ: In which part of the city are you most likely\n" +
        "to find these objects?"; // Corrected typo in "Hint"

    public Canvas dialogueCanvas;
    private TextMeshProUGUI dialogueText;

    public TextMeshProUGUI scoreText;

    public GameObject ParkingSign;

    private string[] parts; // Define the parts array here

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

        if (scoreText != null)
        {
            // Split the score text and store the parts in the array
            parts = scoreText.text.Split(' ');

            if (parts.Length > 0)
            {
                string numberPart = parts[0]; // Get the first part
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
    }

    IEnumerator HideObjectDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (ParkingSign != null)
        {
            ParkingSign.SetActive(false);
        }
        else
        {
            Debug.LogError("ParkingSign GameObject is not assigned.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("Score: "+ parts[0]);
            if (ScoreManager.instance.score == 3) // Check if parts is not null and has elements
            {
                if (dialogueText != null)
                {
                    dialogueText.text = npcMessage;
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
                Debug.LogError("Score is not 3!\nCurrent score: " + ScoreManager.instance.score);
            }
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
}
