using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class closeplayer : MonoBehaviour
{
    public string npcMessage = "Hello, Player!";
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

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

    //public float talkingDistance = 3f;


    /*public string npcMessage = "Hello, Player!";

    private Text dialogueText = null;

    void Start()
    {
        // Assuming the Text component is attached to the NPC GameObject
        GameObject npcObject = GameObject.FindWithTag("NPC"); // Replace "NPC" with the actual tag of your NPC GameObject

        if (npcObject != null)
        {
            // Assuming the Text component is attached to the same GameObject
            dialogueText = GetComponentInChildren<Text>();

            if (dialogueText == null)
            {
                Debug.LogError("Text component not found!");
            }
            else
            {
                dialogueText.enabled = false;
            }
        }
        else
        {
            Debug.LogError("NPC GameObject not found!");
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && dialogueText != null)
        {
            dialogueText.text = npcMessage;
            dialogueText.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && dialogueText != null)
        {
            dialogueText.enabled = false;
        }
    }*/

    /*bool player_detection = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(player_detection && Input.GetKeyDown(KeyCode.F))
        {
            print("Dialogue Started!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_detection = false;
        }
    }*/
//}
