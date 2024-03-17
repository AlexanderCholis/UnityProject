using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaygroundPark_CheckObjects : MonoBehaviour
{
    public string message = "You found all objects, you can now continue to your next" +
        "\nriddle located in the parking garage!";

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

    public Canvas dialogueCanvas; // Link this in the Unity Editor
    public TextMeshProUGUI dialogueText;

    // Variable to store the last clicked button
    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

    int score;

    // Start is called before the first frame update
    void Start()
    {
        dialogueText = dialogueCanvas.transform.Find("Text1").GetComponent<TextMeshProUGUI>();

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

        score = ScoreManager.score;
        Debug.Log("Score " + score);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogueText != null)
            {
                if (selectedGameMode == "EASY")
                {
                    // easy objects hidden
                    if (!BlackCar.activeSelf && !BlackWheel.activeSelf &&
                        !BlackSledgeHammer.activeSelf && !Parkgarage_sign.activeSelf
                        && score == 4)
                    {
                        Debug.Log("Score " + score);
                        dialogueText.text = message;
                    }
                }
                else if (selectedGameMode == "MEDIUM")
                {
                    // medium objects hidden
                    if (!BlackWheel1.activeSelf && !BlackPillow.activeSelf && 
                        !BlackDonut.activeSelf && !BlackRock.activeSelf
                        && score == 8)

                    {
                        Debug.Log("Score " + score);
                        dialogueText.text = message;
                    }

                }
               else if (selectedGameMode == "HARD")
               {
                    // hard mode hidden
                    if (!RedCar.activeSelf && !RedRock.activeSelf && !RedWineGlass.activeSelf && 
                        !RedCupcake.activeSelf && !RedFlower.activeSelf && score == 15)

                    {
                        Debug.Log("Score " + score);
                        dialogueText.text = message;
                    }
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
