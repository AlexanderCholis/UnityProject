using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Close_Rock_Playground_Hard : MonoBehaviour
{
    public string npcMessage = "You found the rock, keep going!";
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    public GameObject RedRock;

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
        if (RedRock != null)
        {
            RedRock.SetActive(false);
        }
        else
        {
            Debug.LogError("RedRock GameObject is not assigned.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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

