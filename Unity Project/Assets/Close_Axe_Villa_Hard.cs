using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;

public class Close_Axe_Villa_Hard : MonoBehaviour
{
    public LocalizedString AxeHard;
    //public string npcMessage = "You found the axe, keep going!";
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    public GameObject Axe;

    public static bool axeflag = false;

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
        if (Axe != null)
        {
            Axe.SetActive(false);
        }
        else
        {
            Debug.LogError("Axe GameObject is not assigned.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null)
            {
                //dialogueText.text = npcMessage;
                string localizedMessage = AxeHard.GetLocalizedString();
                dialogueText.text = localizedMessage;

                ScoreManager.instance.AddPointEasyMode();

                axeflag = true;

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

    /*
    IEnumerator ShowDialogueAfterDelay(float delay)
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

