using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_NPC_Playground : MonoBehaviour
{
    public string npcMessageEasy = "Hello there, you are located in the playground park. Your\n"+
        "mission is to collect 3 black objects and one traffic sign that are scattered in the\n"+
        "park in order to continue to your next riddle. Good luck!";

    public string npcMessageMedium = "Hello there, you are located in the playground park. Your\n" +
       "mission is to collect 4 black objects that are scattered in the\n" +
       "park in order to continue to your next riddle. Good luck!";

    public string npcMessageHard = "Hello there, you are located in the playground park. Your\n" +
        "mission is to collect 5 red objects that are scattered in the\n" +
        "park in order to continue to your next riddle. Good luck!";


    public Canvas dialogueCanvas; // Link this in the Unity Editor
    public TextMeshProUGUI dialogueText;

    // easy mode objects
    public GameObject BlackCar;
    public GameObject BlackWheel;
    public GameObject BlackSledgeHammer;
    public GameObject Parkgarage_sign;
   

    // medium mode objects
    public GameObject BlackWheel1;
    public GameObject BlackPillow;
    public GameObject BlackDonut;
    public GameObject BlackRock;

    // hard mode objects
    public GameObject RedCar;
    public GameObject RedRock;
    public GameObject RedWineGlass;
    public GameObject RedCupcake;
    public GameObject RedFlower;

    

    // Variable to store the last clicked button
    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";


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

        /*if (RedCar != null && RedRock != null &&RedWineGlass != null && RedCupcake != null && RedFlower != null
            && BlackWheel1 != null && BlackPillow != null && BlackDonut != null && BlackRock != null)
        {
            RedCar.SetActive(false);
            RedRock.SetActive(false);
            RedWineGlass.SetActive(false);
            RedCupcake.SetActive(false);
            RedFlower.SetActive(false);

            BlackWheel1.SetActive(false);
            BlackPillow.SetActive(false);
            BlackDonut.SetActive(false);
            BlackRock.SetActive(false);
        }
        else
        {
            Debug.LogError("Some of your objects  is/are not assigned.");
        }*/

        
        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("Gamemode: " + selectedGameMode);


        // depending on mode show and hide the nessesary objects
        if (selectedGameMode == "EASY")
        {
            // show easy mode objects, hide medium and hard mode objects4
            
            // show
            // easy
            BlackCar.SetActive(true);
            BlackWheel.SetActive(true);
            BlackSledgeHammer.SetActive(true);
            Parkgarage_sign.SetActive(true);

            // hide
            // medium
            BlackWheel1.SetActive(false);
            BlackPillow.SetActive(false);
            BlackDonut.SetActive(false);
            BlackRock.SetActive(false);

            // hard
            RedCar.SetActive(false);
            RedRock.SetActive(false);
            RedWineGlass.SetActive(false);
            RedCupcake.SetActive(false);
            RedFlower.SetActive(false);
        }
        else if (selectedGameMode == "MEDIUM")
        {
            // show medium mode objects, hide easy and hard

            // show
            // medium
            BlackWheel1.SetActive(true);
            BlackPillow.SetActive(true);
            BlackDonut.SetActive(true);
            BlackRock.SetActive(true);

            // hide
            // easy
            BlackCar.SetActive(false);
            BlackWheel.SetActive(false);
            BlackSledgeHammer.SetActive(false);
            Parkgarage_sign.SetActive(false);

            // hard
            RedCar.SetActive(false);
            RedRock.SetActive(false);
            RedWineGlass.SetActive(false);
            RedCupcake.SetActive(false);
            RedFlower.SetActive(false);
        }
        else if(selectedGameMode == "HARD")
        {
            // show hard mode objects, hide easy and medium

            // show
            // hard
            RedCar.SetActive(true);
            RedRock.SetActive(true);
            RedWineGlass.SetActive(true);
            RedCupcake.SetActive(true);
            RedFlower.SetActive(true);

            // hide
            // easy
            BlackCar.SetActive(false);
            BlackWheel.SetActive(false);
            BlackSledgeHammer.SetActive(false);
            Parkgarage_sign.SetActive(false);

            // medium
            BlackWheel1.SetActive(false);
            BlackPillow.SetActive(false);
            BlackDonut.SetActive(false);
            BlackRock.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null)
            {
                if (selectedGameMode == "EASY")
                    dialogueText.text = npcMessageEasy;
                else if(selectedGameMode == "MEDIUM")
                    dialogueText.text = npcMessageMedium;
                else if(selectedGameMode == "HARD")
                    dialogueText.text = npcMessageHard;
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
