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
    public string safeCode;
    public GameObject CodePanel;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CodeText.text = codeTextValue;

        if (codeTextValue == safeCode)
        {
            anim.SetTrigger("OpenSchoolDoor");
            CodePanel.SetActive(false);
        }

        if(codeTextValue.Length >= 4)
        {
            codeTextValue = "";
        }

        if (Input.GetKey(KeyCode.E) && isAtDoor == true)
        {
            CodePanel.SetActive(true);
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
}
