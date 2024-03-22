using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;

public class WomanCafe : MonoBehaviour
{
    //public string npcMessage = "Hello Sir! You want your usual coffee, right? Today we also have an offer for coffee and a piece of pie at $2.58.";
    public LocalizedString WomanCafeMessage;

    public Canvas dialogueCanvas;
    //private Text dialogueText;

    private TextMeshProUGUI dialogueText;

    public static string selectedGameMode;
    private const string GameModeKey = "GameMode";

    void Start()
    {
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

        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("GameMode:" + selectedGameMode);
    }


    void OnTriggerEnter(Collider other)
    {
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        if (selectedGameMode == "MEDIUM" && other.CompareTag("Player"))
        {
            string localizedMessage = WomanCafeMessage.GetLocalizedString();
            dialogueText.text = localizedMessage;
            //dialogueText.text = npcMessage;
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
