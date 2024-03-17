using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;
    public string Message = "You've collected all diamonds! The residents of this city are 49.\n" +
        "Your next mission is to find the lady who is around the perimeter of the park, she will talk to you when you get next to her.";
    private TextMeshProUGUI missionText;
    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
        missionText = GetComponent<TextMeshProUGUI>();

        selectedGameMode = PlayerPrefs.GetString(GameModeKey);
        Debug.Log("GameMode:" + selectedGameMode);
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();

        if (selectedGameMode == "EASY")
        {

            if (playerInventory.NumberOfDiamonds == 49)
            {
                ShowMessage();
            }
        }
        else if (selectedGameMode == "MEDIUM")
        {

            if (playerInventory.NumberOfDiamonds == 7)
            {
                ShowMessage();
            }
        }
        else if (selectedGameMode == "HARD")
        {

            if (playerInventory.NumberOfDiamonds == 4)
            {
                ShowMessage();
            }
        }

    }

    // Corrected method declaration
    private void ShowMessage()
    {
        if (selectedGameMode == "EASY")
        {
            Debug.Log("You've collected all diamonds! The residents of this city are 49.");
            missionText.text = Message;
        }
        else if (selectedGameMode == "MEDIUM")
        {
            Debug.Log("You've collected all diamonds! The residents of this city are 49 (diamonds*7).");
            missionText.text = Message;
        }
        else if (selectedGameMode == "HARD")
        {
            Debug.Log("You've collected all diamonds! The residents of this city are 49 [(diamonds+3)*7].");
            missionText.text = Message;
        }
    }
}
