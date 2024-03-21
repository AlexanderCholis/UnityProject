using UnityEngine;
using UnityEngine.UI;

public class ManCafe : MonoBehaviour
{
    public string npcMessage = "Hello Sir! You want your usual coffee, right? Today we also have an offer for coffee and a piece of pie at $2.58.";
    public Canvas dialogueCanvas;
    private Text dialogueText;

    public static string selectedGameMode;
    private const string GameModeKey = "GameMode";

    void Start()
    {
        dialogueText = dialogueCanvas.GetComponentInChildren<Text>();

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
        if (selectedGameMode == "HARD" && other.CompareTag("Player"))
        {
            dialogueText.text = npcMessage;
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
