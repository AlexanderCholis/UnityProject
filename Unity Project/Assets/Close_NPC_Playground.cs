using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Close_NPC_Playground : MonoBehaviour
{
    public string npcMessage = "Hello there, you are located in the playground park. Your\n"+
        "mission is to collect 3 black objects and one traffic sign that are scattered in the\n"+
        "park in order to continue to your next riddle. Good luck!";

    public Canvas dialogueCanvas; // Link this in the Unity Editor
    private TextMeshProUGUI dialogueText;

    // hide the medium and hard mode objects
    
    // hide medium mode objects
    public GameObject BlackWheel1;
    public GameObject BlackPillow;
    public GameObject BlackDonut;
    public GameObject BlackRock;

    // hide hard mode objects
    public GameObject RedCar;
    public GameObject RedRock;
    public GameObject RedWineGlass;
    public GameObject RedCupcake;
    public GameObject RedFlower;



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

        if (RedCar != null && RedRock != null &&RedWineGlass != null && RedCupcake != null && RedFlower != null
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
