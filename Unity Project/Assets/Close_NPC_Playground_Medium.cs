using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_NPC_Playground_Medium : MonoBehaviour
{
    public string npcMessage = "Hello there, you are located in the playground park. Your\n" +
        "mission is to collect 4 black objects that are scattered in the\n" +
        "park in order to continue to your next riddle. Good luck!";

    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    // hide the easy mode objects
    public GameObject BlackWheel;
    public GameObject BlackCar;
    public GameObject BlackHammer;
    public GameObject ParkingSign;

    void Start()
    {
        // Assuming the Text component is a child of the Canvas
        //dialogueText = dialogueCanvas.GetComponentInChildren<Text>();
        dialogueText = dialogueCanvas.transform.Find("Text1").GetComponent<TextMeshProUGUI>();

        if (dialogueText == null)
        {
            Debug.LogError("Text component not found in the Canvas!");
        }
        else
        {
            dialogueCanvas.enabled = false;
        }

        if (BlackWheel != null && BlackCar != null && BlackHammer != null && ParkingSign != null)
        {
            BlackWheel.SetActive(false);
            BlackCar.SetActive(false);
            BlackHammer.SetActive(false);
            ParkingSign.SetActive(false);
        }
        else
        {
            Debug.LogError("Some of your objects  is not assigned.");        
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null)
            {
                dialogueText.text = npcMessage;
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
