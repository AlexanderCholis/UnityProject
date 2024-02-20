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

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
        missionText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();

        if (playerInventory.NumberOfDiamonds == 49)
        {
            ShowMessage();
        }
    }

    // Corrected method declaration
    private void ShowMessage()
    {
        Debug.Log("You've collected all diamonds! The residents of this city are 49.");
        missionText.text = Message;
    }
}
