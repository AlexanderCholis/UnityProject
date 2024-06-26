using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_NPC_In_Villa_Hard : MonoBehaviour
{
    public string npcMessage = "Hello there, you have been assigned a very important role.\n" +
      "You are a detective investigating a murder case. Search the house and collect the" +
      " \n6 objects that incriminate him.The objects are scattered in the different areas" +
      "of the house.\nHint: We have testimonies that there may be a female captive.\nBe careful and good luck";

    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    // hide medium mode objects
    public GameObject BlackGun;
    public GameObject RustyKnife;
    public GameObject GunCase;
    public GameObject Snipper;
    public GameObject Sight;
    public GameObject CombatKnife;

    // Player object to hide from medium mode
    public GameObject TerrifiedWoman;

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

        if (BlackGun != null && RustyKnife  != null && GunCase != null && Snipper != null
            && Sight != null && CombatKnife != null && TerrifiedWoman != null)
        {
            BlackGun.SetActive(false);
            RustyKnife.SetActive(false);
            GunCase.SetActive(false);
            Snipper.SetActive(false);
            Sight.SetActive(false);
            CombatKnife.SetActive(false);
            TerrifiedWoman.SetActive(false);
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
