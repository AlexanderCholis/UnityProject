using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWave : MonoBehaviour
{
    public Animator animator; //animator that controls NPC's animations

    void Start()
    {
        // In the Start method (called once when the script starts), get the Animator component
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)

    {

        //filter only player

        if (other.CompareTag("Player"))

        {

            //Notify to wave

            animator.SetTrigger("Wave");

        }

    }

}
