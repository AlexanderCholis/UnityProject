using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject Canvas2; // Reference to the canvas GameObject

    private void Start()
    {
        // Deactivate the canvas when the game starts
        Canvas2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your main character has the "Player" tag
        {
            Canvas2.SetActive(true); // Show the canvas when the player enters the trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your main character has the "Player" tag
        {
            Canvas2.SetActive(false); // Hide the canvas when the player exits the trigger
        }
    }
}
