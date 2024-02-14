using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText; 

    // Start is called before the first frame update
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfDiamonds.ToString();

        if (playerInventory.NumberOfDiamonds == 49)
        {
            ShowCompletionMessage();
        }
    }

    private void ShowCompletionMessage()
    {
        // You can replace this with your own logic to show a message on the screen
        Debug.Log("You've collected all diamonds! The residents of this city are 49.");
    }
}