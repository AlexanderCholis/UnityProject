using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_Player_In_Villa : MonoBehaviour
{
     public string npcMessage = "Hello there, you have been assigned a very important role.\n" +
        "You are a detective investigating a murder case. Search the house and collect the" +
        " \n7 objects that incriminate him.The objects are scattered in the different areas" +
        "of the house.\nHint: We have testimonies that there may be a female captive.\nBe careful and good luck";

    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    // hide the hard mode objects
    public GameObject Axe;
    public GameObject Gun;
    public GameObject Bullets;
    public GameObject Pistol;
    public GameObject Knife;
    public GameObject GunCase;
    public GameObject ShotGun;

    public GameObject RustyKnife;

    // Player object to hide from hard mode
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

        if (Axe != null && Gun != null && Bullets != null && Pistol != null
           && Knife != null && GunCase != null && ShotGun != null && TerrifiedWoman != null && RustyKnife != null)
        {
            Axe.SetActive(false);
            Gun.SetActive(false);
            Bullets.SetActive(false);
            Pistol.SetActive(false);
            Knife.SetActive(false);
            GunCase.SetActive(false);
            ShotGun.SetActive(false);
            TerrifiedWoman.SetActive(false);
            RustyKnife.SetActive(false);
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
