using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>(); // Corrected typo here

        if (playerInventory != null)
        {
            playerInventory.DiamondsCollected(); // Corrected method name here
            gameObject.SetActive(false);
        }
    }
}