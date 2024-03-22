using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;


public class WomanSittingParkScript : MonoBehaviour

{
    public LocalizedString WomanSittingParkMessage;
    /*public string npcMessage = "Welcome to the park! \n" +
        "Your first mission is to collect all the diamonds around the park,\n" +
        "so you can answer this question:\n" +
        "How many are the residents of the city? ";
    */
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;
    public GameObject Gems;
    public GameObject Gems2;
    public GameObject Gems3;

    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

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

        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("GameMode:" + selectedGameMode);


    }

    void OnTriggerEnter(Collider other)
    {
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        if (selectedGameMode == "EASY")
        {

            if (other.CompareTag("Player"))
            {
                if (dialogueText != null)
                {
                    string localizedMessage = WomanSittingParkMessage.GetLocalizedString();
                    dialogueText.text = localizedMessage;
                    //dialogueText.text = npcMessage;
                    Gems.SetActive(true);
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
        else if (selectedGameMode == "MEDIUM")
        {

            if (other.CompareTag("Player"))
            {
                if (dialogueText != null)
                {
                    string localizedMessage = WomanSittingParkMessage.GetLocalizedString();
                    dialogueText.text = localizedMessage;
                    //dialogueText.text = npcMessage;
                    Gems2.SetActive(true);
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
        else if (selectedGameMode == "HARD")
        {

            if (other.CompareTag("Player"))
            {
                if (dialogueText != null)
                {
                    string localizedMessage = WomanSittingParkMessage.GetLocalizedString();
                    dialogueText.text = localizedMessage;
                    //dialogueText.text = npcMessage;
                    Gems3.SetActive(true);
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
