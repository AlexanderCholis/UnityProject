using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfDiamonds
    {
        get;
        private set;
    }

    public UnityEvent<PlayerInventory> onDiamondCollected = new UnityEvent<PlayerInventory>(); // Initialize UnityEvent

    public void DiamondsCollected()
    {
        NumberOfDiamonds++;
        onDiamondCollected.Invoke(this);
    }
}
