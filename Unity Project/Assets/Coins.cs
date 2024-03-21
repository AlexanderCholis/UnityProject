using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInvCoins playerInventory = other.GetComponent<PlayerInvCoins>(); 

        if (playerInventory != null)
        {
            playerInventory.CoinsCollected(); 
            gameObject.SetActive(false);
        }
    }
}
