using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;

public class WomanInsideSchool : MonoBehaviour
{
    public LocalizedString WomanSchoolMessage;

    /*
    public string npcMessage = "You have successfully entered the room! \n" +
        "I'm the substitute teacher. The school teacher is missing. \n" +
        "Continue to the villa for more information!";
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
                string localizedMessage = WomanSchoolMessage.GetLocalizedString();
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
