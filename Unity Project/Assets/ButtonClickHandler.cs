using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    //public Manager manager; // Reference to the Manager script
    private Button button; // Reference to the button component
    private Image buttonImage;

    private void Start()
    {
        // Get the button component attached to this GameObject
        button = GetComponent<Button>();

        // Get the image component attached to the button GameObject
        buttonImage = button.image;

        // Add an onClick listener to the button
        button.onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        // Change the color of the button image to green
        buttonImage.color = Color.green;

        // Call the correctAnswer method in the Manager script
        //manager.correctAnswer();
    }
}
