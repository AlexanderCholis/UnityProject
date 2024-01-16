using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalker : MonoBehaviour
{
    private Animator animator;
    private bool isWalkingForward = true;
    private float distanceWalked = 0f;
    private float walkSpeed = 2.0f;
    private float walkDistance = 10.0f;
    private float backwardRotation = 270.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float direction = isWalkingForward ? 1.0f : -1.0f;
        float movement = direction * walkSpeed * Time.deltaTime;

        // Move the NPC forward or backward
        transform.Translate(Vector3.forward * movement);

        // Update the distance walked
        distanceWalked += Mathf.Abs(movement);

        // Set the "isWalking" parameter in the Animator
        animator.SetBool("isWalking", true);

        // Check if reached the desired distance
        if (distanceWalked >= walkDistance)
        {
            // Reverse direction and reset distance
            isWalkingForward = !isWalkingForward;
            distanceWalked = 0f;

            // Set the "isWalking" parameter in the Animator
            animator.SetBool("isWalking", false);

            // Rotate the player to 270 degrees when walking back
            if (!isWalkingForward)
            {
                transform.rotation = Quaternion.Euler(0.0f, backwardRotation, 0.0f);
            }
        }
    }
}














