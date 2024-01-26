using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalking : MonoBehaviour
{
    public string npcMessage = "Hello, Player!";
    private Canvas dialogueCanvas; // Assuming the Canvas is a child of the NPC

    void Start()
    {
        // Assuming the Canvas component is attached to the NPC GameObject
        dialogueCanvas = GetComponentInChildren<Canvas>();

        if (dialogueCanvas == null)
        {
            Debug.LogError("Canvas component not found on NPC GameObject!");
        }
        else
        {
            dialogueCanvas.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && dialogueCanvas != null)
        {
            StartDialogue();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && dialogueCanvas != null)
        {
            EndDialogue();
        }
    }

    void StartDialogue()
    {
        dialogueCanvas.enabled = true;
        Text dialogueText = dialogueCanvas.GetComponentInChildren<Text>();

        if (dialogueText != null)
        {
            dialogueText.text = npcMessage;
        }
        else
        {
            Debug.LogError("Text component not found in the Canvas!");
        }
    }

    void EndDialogue()
    {
        dialogueCanvas.enabled = false;
    }
}
