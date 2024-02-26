using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory1 playerInventory = other.GetComponent<PlayerInventory1>(); // Corrected typo here

        if (playerInventory != null)
        {
            playerInventory.DiamondsCollected(); // Corrected method name here
            gameObject.SetActive(false);
        }
    }
}