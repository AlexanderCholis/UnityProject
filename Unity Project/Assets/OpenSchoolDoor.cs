using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSchoolDoor : MonoBehaviour
{
    private Animator anim;
    private bool isAtDoor = false;

    [SerializeField] private TextMeshProGUI CodeText;
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
