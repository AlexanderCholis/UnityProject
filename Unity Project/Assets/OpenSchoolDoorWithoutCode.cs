using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSchoolDoorWithoutCode : MonoBehaviour
{
    private Animator anim;
    private bool isAtDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("OpenDoor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isAtDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAtDoor = false;
    }
}
