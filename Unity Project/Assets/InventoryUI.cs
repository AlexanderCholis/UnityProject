using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Localization;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;
    /*public string Message = "You've collected all diamonds! The residents of this city are 49.\n" +
        "Your next mission is to find the lady who is around the perimeter of the park, she will talk to you when you get next to her.";
   */
    public LocalizedString MessageEasy;
    public LocalizedString MessageMedium;
    public LocalizedString MessageHard;

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
                string localizedMessage = MessageEasy.GetLocalizedString();
                missionText.text = localizedMessage;
            }
        }
        else if (selectedGameMode == "MEDIUM")
        {

            if (playerInventory.NumberOfDiamonds == 7)
            {
                string localizedMessage = MessageMedium.GetLocalizedString();
                missionText.text = localizedMessage;
            }
        }
        else if (selectedGameMode == "HARD")
        {

            if (playerInventory.NumberOfDiamonds == 4)
            {
                string localizedMessage = MessageHard.GetLocalizedString();
                missionText.text = localizedMessage;
            }
        }
    }


    /*private void ShowMessage()
    {
        if (selectedGameMode == "EASY")
        {
            Message = "You've collected all diamonds! The residents of this city are 49." + "\n Your next mission is to find the lady who is around the perimeter of the park, she will talk to you when you get next to her.";
            missionText.text = Message;
        }
        else if (selectedGameMode == "MEDIUM")
        {
            Message = "You've collected all diamonds! The residents of this city are 49 (diamonds*7)." + "\n Your next mission is to find the lady who is around the perimeter of the park, she will talk to you when you get next to her.";
            missionText.text = Message;
        }
        else if (selectedGameMode == "HARD")
        {
            Message = "You've collected all diamonds! The residents of this city are 49 [(diamonds+3)*7]." + "\n Your next mission is to find the lady who is around the perimeter of the park, she will talk to you when you get next to her.";
            missionText.text = Message;
        }
    }*/
}
