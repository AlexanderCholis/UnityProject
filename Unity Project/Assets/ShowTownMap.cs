using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowTownMap : MonoBehaviour
{
    public Image scooter3; // Assign the image to show in the inspector

    // Called when the button is clicked
    public void OnButtonClick()
    {
        // Show the image
        if (scooter3 != null)
        {
            scooter3.enabled = true;
        }
    }
}
