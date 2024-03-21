using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerInvCoins : MonoBehaviour
{
    public int NumberOfCoins
    {
        get;
        private set;
    }

    public UnityEvent<PlayerInvCoins> onCoinsCollected = new UnityEvent<PlayerInvCoins>(); 
    public void CoinsCollected()
    {
        NumberOfCoins++;
        onCoinsCollected.Invoke(this);
    }
}
