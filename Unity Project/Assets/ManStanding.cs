using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;

public class ManStanding : MonoBehaviour
{
    //public string npcMessage = "Hey! How are you? Last time at your home I think I accidentally threw a box of playing cards in the trash. Can you look for it?";

    public LocalizedString ManStandingCafeMessage;

    public Canvas dialogueCanvas;
    //private Text dialogueText;

    private TextMeshProUGUI dialogueText;

    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

    void Start()
    {
        dialogueText = dialogueCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        //dialogueText = dialogueCanvas.GetComponentInChildren<Text>();

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

        if (selectedGameMode == "HARD" && other.CompareTag("Player"))
        {
            //dialogueText.text = npcMessage;
            //dialogueCanvas.Text = LocalizedString;
            string localizedMessage = ManStandingCafeMessage.GetLocalizedString();
            dialogueText.text = localizedMessage;
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
