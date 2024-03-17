using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenSchoolDoor : MonoBehaviour
{
    private Animator anim;
    private bool isAtDoor = false;

    [SerializeField] private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    private string safeCode;
    public GameObject CodePanel;

    public GameObject leftDoor; // Reference to the left door
    public GameObject rightDoor; // Reference to the right door
    public GameObject npcRemyMedium; // Reference to the NPC GameObject
    public GameObject npcRemyHard; // Reference to the NPC GameObject
    public GameObject npcTeacher;
    public GameObject npcStudent;

    //Variable to store the last clicked button
    public static string selectedGameMode;

    private const string GameModeKey = "GameMode";

    private bool doorsRotated = false; // Flag to track if doors are already rotated

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        string selectedGameMode = PlayerPrefs.GetString(GameModeKey);

        // Set safeCode based on the selected game mode
        if (selectedGameMode == "MEDIUM")
        {
            safeCode = "258";
        }
        else if (selectedGameMode == "HARD")
        {
            safeCode = "634";
        }

        CodeText.text = codeTextValue;

        if (codeTextValue == safeCode)
        {
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);
        }

        if(codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }

        if (Input.GetKey(KeyCode.K) && isAtDoor == true)
        {
            CodePanel.SetActive(true);
        }

        if (selectedGameMode == "EASY")
        {
            //npcRemyMedium.setActive(false); 
            //npcRemyHard.setActive(false);
            npcTeacher.SetActive(false);
            npcStudent.SetActive(false);
        }

        if (selectedGameMode == "MEDIUM")
        {
            npcRemyMedium.SetActive(true); 
            npcRemyHard.SetActive(false);
            npcTeacher.SetActive(true);
            npcStudent.SetActive(false);
        }
        /*
        if (selectedGameMode == "HARD")
        {
            RotateDoors();
            npcRemyHard.SetActive(true);
            npcRemyMedium.SetActive(false);
            npcTeacher.SetActive(false);
            npcStudent.SetActive(true);
        }
        */
        if (selectedGameMode == "HARD")
        {
            if (isAtDoor && npcRemyHard.activeSelf) // Check if the player is at the door and npcRemyHard is active
            {
                RotateDoors();
                npcRemyHard.SetActive(true);
                npcRemyMedium.SetActive(false);
                npcTeacher.SetActive(false);
                npcStudent.SetActive(true);
            }
            else
            {
                npcRemyHard.SetActive(true);
                npcRemyMedium.SetActive(false);
                npcTeacher.SetActive(false);
                npcStudent.SetActive(true);
            }
        }
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
        CodePanel.SetActive(false);
    }

    public void AddDigit(string digit)
    { 
        codeTextValue += digit;
    }

    private void RotateDoors()
    {
        if (!doorsRotated)
        {
            // Rotate the left door to 90 degrees
            leftDoor.transform.rotation = Quaternion.Euler(0, 90, 0);

            // Rotate the right door to -90 degrees
            rightDoor.transform.rotation = Quaternion.Euler(0, -90, 0);

            doorsRotated = true; // Set the flag to true to indicate that doors are rotated
        }
    }
}
