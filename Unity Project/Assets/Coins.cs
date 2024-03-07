using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInvCoins playerInventory = other.GetComponent<PlayerInvCoins>(); // Corrected typo here

        if (playerInventory != null)
        {
            playerInventory.CoinsCollected(); // Corrected method name here
            gameObject.SetActive(false);
        }
    }
}
