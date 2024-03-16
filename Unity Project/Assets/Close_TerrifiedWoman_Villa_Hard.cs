using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_TerrifiedWoman_Villa_Hard : MonoBehaviour
{
    public string npcMessage = "There is somewhere hidden the deadly gun." +
        " Hint: Ask in the cafeteria for more info!";

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
                dialogueText.text = npcMessage;
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
        if (Close_Axe_Villa_Hard.axeflag && Close_Gun_Villa_Hard.gunflag && Close_Bullets_Villa_Hard.bulletsflag
            && Close_Pistol_Villa_Hard.pistolflag && Close_Knife_Villa_Hard.knifeflag
            && Close_GunCase_Villa_Hard.guncaseflag && Close_ShotGun_Villa_Hard.shotgunflag
            && Close_TerrifiedWoman_Villa_Hard.womanflag && Close_TrashKnife_Villa_Hard.knifeflag)
        {
            Debug.Log("All easy mode hidden!!!!!");
            StartCoroutine(ShowDialogueAfterDelay(2f));
        }
    }*/
}

