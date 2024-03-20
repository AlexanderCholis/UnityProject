using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Localization;

public class Close_Player_In_Villa : MonoBehaviour
{
    public LocalizedString PlayerVillaMediumMessage;
    public LocalizedString PLayerVillaHardMessage;

    /*public string npcMessageEasy = "Hello Player";

     public string npcMessageMedium = "Hello there, you have been assigned a very important role. You are\na detective investigating a murder case. Search the house and\ncollect the 6 objects that incriminate him.The objects are scattered\nin the different areas of the house.Hint: We have testimonies\nthat there may be a female captive.Be careful and good luck.";

     public string npcMessageHard = "Hello there, you have been assigned a very important role. You are\na detective investigating a murder case. Search the house and\ncollect the 8 objects that incriminate him.The objects are scattered\nin the different areas of the house.Hint: We have testimonies that there may be a female captive.\nBe careful and good luck.";
    */
    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    // medium mode objects
    public GameObject BlackGun;
    public GameObject RustyKnife;
    public GameObject GunCase;
    public GameObject Sniper;
    public GameObject Sight;
    public GameObject CombatKnife;
    public GameObject WomanTerrified;

    // hard mode objects
    public GameObject Axe;
    public GameObject Gun;
    public GameObject Bullets;
    public GameObject Pistol;
    public GameObject Knife;
    public GameObject GunCase1;
    public GameObject ShotGun;
    public GameObject RustyKnife1;
    public GameObject TerrifiedWoman1;


    // Variable to store the last clicked button
    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

    public static bool mission = false;


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


        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("Gamemode: " + selectedGameMode);

        if (selectedGameMode == "EASY")
        {
            // hide medium and hard mode objects + turn on collider house

            // hide
            // medium
            BlackGun.SetActive(false);
            RustyKnife.SetActive(false);
            GunCase.SetActive(false);
            Sniper.SetActive(false);
            Sight.SetActive(false);
            CombatKnife.SetActive(false);
            WomanTerrified.SetActive(false);

            // hard
            Axe.SetActive(false);
            Gun.SetActive(false);
            Bullets.SetActive(false);
            Pistol.SetActive(false);
            Knife.SetActive(false);
            GunCase1.SetActive(false);
            ShotGun.SetActive(false);
            TerrifiedWoman1.SetActive(false);
            RustyKnife1.SetActive(false);
        }
        else if (selectedGameMode == "MEDIUM")
        {
            // show medium mode objects and hide hard mode objects

            // show
            // medium
            BlackGun.SetActive(true);
            RustyKnife.SetActive(true);
            GunCase.SetActive(true);
            Sniper.SetActive(true);
            Sight.SetActive(true);
            CombatKnife.SetActive(true);
            WomanTerrified.SetActive(true);

            // hide
            // hard
            Axe.SetActive(false);
            Gun.SetActive(false);
            Bullets.SetActive(false);
            Pistol.SetActive(false);
            Knife.SetActive(false);
            GunCase1.SetActive(false);
            ShotGun.SetActive(false);
            TerrifiedWoman1.SetActive(false);
            RustyKnife1.SetActive(false);

        }
        else if (selectedGameMode == "HARD")
        {
            // show hard objects, hide mefium ones

            // show hard
            Axe.SetActive(true);
            Gun.SetActive(true);
            Bullets.SetActive(true);
            Pistol.SetActive(true);
            Knife.SetActive(true);
            GunCase1.SetActive(true);
            ShotGun.SetActive(true);
            TerrifiedWoman1.SetActive(true);
            RustyKnife1.SetActive(true);

            // hide medium
            BlackGun.SetActive(false);
            RustyKnife.SetActive(false);
            GunCase.SetActive(false);
            Sniper.SetActive(false);
            Sight.SetActive(false);
            CombatKnife.SetActive(false);
            WomanTerrified.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null)
            {
                if (selectedGameMode == "EASY")
                {
                    //dialogueText.text = npcMessageEasy;
                    mission = true;
                }
                else if (selectedGameMode == "MEDIUM")
                {
                    //dialogueText.text = npcMessageMedium;
                    mission = true;

                    string localizedMessage = PlayerVillaMediumMessage.GetLocalizedString();
                    dialogueText.text = localizedMessage;
                }
                else if (selectedGameMode == "HARD")
                {
                    //dialogueText.text = npcMessageHard;
                    mission = true;

                    string localizedMessage = PLayerVillaHardMessage.GetLocalizedString();
                    dialogueText.text = localizedMessage;
                }
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
