using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_Gun_Villa : MonoBehaviour
{
    public string npcMessage = "You found the gun, keep going!";
    public string npcMessage1 = "You found all the hidden objects!";
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    public GameObject BlackGun;

    public int totalHiddenObjects = 1;  // include terrified woman too
    public int hiddenObjectCount = 0; // Counter for hidden objects


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
        if (BlackGun != null)
        {
           
            //hiddenObjectCount++;  // Increment the count when object is hidden
            //CheckHiddenObjects(); // Check if all objects are hidden
            
            BlackGun.SetActive(false);
        }
        else
        {
            Debug.LogError("BlackGun GameObject is not assigned.");
        }
    }

    void HideObject()
    {
        if (BlackGun != null)
        {

            //hiddenObjectCount++;  // Increment the count when object is hidden
            //CheckHiddenObjects(); // Check if all objects are hidden

            BlackGun.SetActive(false);
        }
        else
        {
            Debug.LogError("BlackGun GameObject is not assigned.");
        }

    }

    IEnumerator CheckHiddenObjects(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (BlackGun != null)
        {
            if (hiddenObjectCount == totalHiddenObjects)
            {
                // Show the dialogue message
                if (dialogueText != null)
                {
                    dialogueText.text = npcMessage1;

                }
                else
                {
                    Debug.LogError("Text component not found in the Canvas!");
                }

                dialogueCanvas.enabled = true;
            }
            //HideObject();
        }
        else
        {
            Debug.LogError("BlackGun GameObject is not assigned.");
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

                hiddenObjectCount++;  // Increment the count when object is hidden
                HideObject();

                StartCoroutine(CheckHiddenObjects(3f)); // Check if all objects are hidden
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
