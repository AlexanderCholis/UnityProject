using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;



public class ManInsideSchool : MonoBehaviour
{
    public LocalizedString ManSchoolMediumMessage;
    /*
    public string npcMessage = "Welcome to the school!\n" +
        "In order to enter the room please type 'K'.\n" +
        "To find the password please go\n" +
        "to the cafeteria' employee!";
    */
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;


    // Start is called before the first frame update
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
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null)
            {
                string localizedMessage = ManSchoolMediumMessage.GetLocalizedString();
                dialogueText.text = localizedMessage;
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
}
