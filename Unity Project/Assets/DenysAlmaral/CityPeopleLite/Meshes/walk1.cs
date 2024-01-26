using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk1 : MonoBehaviour
{
    private bool isWalkingForward = true;
    private float distanceWalked = 0f;
    private float walkSpeed = 2.0f;
    private float walkDistance = 10.0f; // Change the walking distance to 10 meters

    void Update()
    {
        float direction = isWalkingForward ? 1.0f : -1.0f;
        float movement = direction * walkSpeed * Time.deltaTime;

        // Move the NPC forward or backward
        transform.Translate(Vector3.forward * movement);

        // Update the distance walked
        distanceWalked += Mathf.Abs(movement);

        // Check if reached the desired distance
        if (distanceWalked >= walkDistance)
        {
            // Rotate the NPC when moving backward
            if (!isWalkingForward)
            {
                // Rotate by 180 degrees (you can adjust this as needed)
                transform.Rotate(Vector3.up, 180f);
            }

            // Reverse direction and reset distance
            isWalkingForward = !isWalkingForward;
            distanceWalked = 0f;
        }
    }
}





