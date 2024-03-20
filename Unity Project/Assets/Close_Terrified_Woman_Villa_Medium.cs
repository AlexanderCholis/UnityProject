using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;

public class Close_Terrified_Woman_Villa_Medium : MonoBehaviour
{
    public LocalizedString WomanMedium;
    //public string npcMessage = "HELPPPP ME PLEASEE!!!";

    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    public static bool womanflag = false;

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
                //dialogueText.text = npcMessage;
                string localizedMessage = WomanMedium.GetLocalizedString();
                dialogueText.text = localizedMessage;

                ScoreManager.instance.AddPointEasyMode();
                womanflag = true;
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

    /*IEnumerator ShowDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        dialogueText.text = "Congratulations! You found all the hidden objects.\n" +
            "You can now continue to your next mission" +
            "\n located in the parking garage!";
        dialogueCanvas.enabled = true;

        yield return new WaitForSeconds(4f); // Wait for 3 seconds

        dialogueCanvas.enabled = false; // Hide the dialogue canvas
    }

    void Update()
    {
        if (Close_Gun_Villa.gunflag && Close_KitchenKnife_Villa_Medium.rustyknifeflag
            && Close_GunCase_Villa_Medium.guncaseflag && Close_Snipper_Villa_Medium.sniperflag
            && Close_Sight_Villa_Medium.sightflag && Close_CombatKnife_Villa_Medium.combatknifeflag 
            && womanflag)
        {
            Debug.Log("All easy mode hidden!!!!!");
            StartCoroutine(ShowDialogueAfterDelay(2f));
        }
    }*/
}
