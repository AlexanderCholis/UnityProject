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

    public UnityEvent<PlayerInventory> onDiamondsCollected = new UnityEvent<PlayerInventory>(); // Initialize UnityEvent

    public void DiamondsCollected()
    {
        NumberOfDiamonds++;
        onDiamondsCollected.Invoke(this);
    }

}
