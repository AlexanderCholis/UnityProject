using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class safe : MonoBehaviour
{
    public GameObject safecode, numtext, incorrecttext, correcttext;
    //public SC_FPSController playerscript;
    public Animator safeOpen;
    public Text numTex;
    public string codeString, correctCode;
    public int stringCharacters = 0;
    public bool interactable, codeDone, safeactive;
    public Button but1, but2, but3, but4, but5, but6, but7, but8, but9, but0;
    int token = 0;
    public Rigidbody playerRigid;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (codeDone == false)
            {
                interactable = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                safecode.SetActive(true);
                playerRigid.constraints = RigidbodyConstraints.FreezeAll;
                //playerscript.enabled = false;
                safeactive = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                interactable = false;
            }
        }
        if (safeactive == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                numtext.SetActive(true);
                correcttext.SetActive(false);
                incorrecttext.SetActive(false);
                stringCharacters = 0;
                codeString = "";
                but1.interactable = true;
                but2.interactable = true;
                but3.interactable = true;
                but4.interactable = true;
                safeactive = false;
                but5.interactable = true;
                but6.interactable = true;
                but7.interactable = true;
                token = 0;
                but8.interactable = true;
                but9.interactable = true;
                but0.interactable = true;
                safecode.SetActive(false);
                //playerscript.enabled = true;
                playerRigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
                interactable = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            numTex.text = codeString;
            if (stringCharacters == 4)
            {
                if (codeString == correctCode)
                {
                    numtext.SetActive(false);
                    correcttext.SetActive(true);
                    but1.interactable = false;
                    but2.interactable = false;
                    but3.interactable = false;
                    but4.interactable = false;
                    but5.interactable = false;
                    but6.interactable = false;
                    but7.interactable = false;
                    but8.interactable = false;
                    but9.interactable = false;
                    but0.interactable = false;
                    codeDone = true;
                    if (token == 0)
                    {
                        safeOpen.SetTrigger("open");
                        StartCoroutine(endSesh());
                        token = 1;
                    }
                }
                else
                {
                    numtext.SetActive(false);
                    incorrecttext.SetActive(true);
                    but1.interactable = false;
                    but2.interactable = false;
                    but3.interactable = false;
                    but4.interactable = false;
                    but5.interactable = false;
                    but6.interactable = false;
                    but7.interactable = false;
                    but8.interactable = false;
                    but9.interactable = false;
                    but0.interactable = false;
                    if (token == 0)
                    {
                        StartCoroutine(endSesh());
                        token = 1;
                    }
                }
            }
        }
    }
    IEnumerator endSesh()
    {
        yield return new WaitForSeconds(2.5f);
        numtext.SetActive(true);
        correcttext.SetActive(false);
        incorrecttext.SetActive(false);
        stringCharacters = 0;
        codeString = "";
        but1.interactable = true;
        but2.interactable = true;
        but3.interactable = true;
        but4.interactable = true;
        safeactive = false;
        but5.interactable = true;
        but6.interactable = true;
        but7.interactable = true;
        token = 0;
        but8.interactable = true;
        but9.interactable = true;
        but0.interactable = true;
        safecode.SetActive(false);
        playerRigid.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        //playerscript.enabled = true;
        interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void pressedOne()
    {
        codeString = codeString + "1";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedTwo()
    {
        codeString = codeString + "2";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedThree()
    {
        codeString = codeString + "3";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedFour()
    {
        codeString = codeString + "4";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedFive()
    {
        codeString = codeString + "5";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedSix()
    {
        codeString = codeString + "6";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedSeven()
    {
        codeString = codeString + "7";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedEight()
    {
        codeString = codeString + "8";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedNine()
    {
        codeString = codeString + "9";
        stringCharacters = stringCharacters + 1;
    }
    public void pressedZero()
    {
        codeString = codeString + "0";
        stringCharacters = stringCharacters + 1;
    }
}
