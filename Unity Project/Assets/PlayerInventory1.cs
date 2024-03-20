using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory1 : MonoBehaviour
{
    public int NumberOfDiamonds
    {
        get;
        private set;
    }

    public UnityEvent<PlayerInventory1> onDiamondsCollected = new UnityEvent<PlayerInventory1>(); // Initialize UnityEvent

    public void DiamondsCollected()
    {
        NumberOfDiamonds++;
        onDiamondsCollected.Invoke(this);
    }

}
