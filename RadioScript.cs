using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioScript : MonoBehaviour
{
    bool enter = false; // are we in the collider
    bool hasAntenna = false;
    bool hasHeadPhones = false;
    bool hasRadio = false;
    bool radioFinalGUI = false; // are we in the final event
    bool radioFinalGUIOnce = true; //ensure we can use the end event only once
    public Text radio;
    public Text objective;
    public DoorScriptLocked doorScriptLocked;
    public DoorScriptLocked doorScriptLocked2;
    public Text radioText;
    int radioItems = 0;

    private void Start()
    {
        radioText.GetComponent<Text>();
        radioText.alignment = TextAnchor.LowerLeft;
        radioText.fontSize = 27;
        radioText.text = radioItems+"/3";
    }

    public void setHasAntenna(bool antenna)
    {
        hasAntenna = antenna;
        radioItems++;
        radioText.text = radioItems + "/3";
        if (hasAntenna && hasHeadPhones && hasRadio) StartCoroutine(enumerator());
    }

    public void setHasHeadphones(bool headphones)
    {
        hasHeadPhones = headphones;
        radioItems++;
        radioText.text = radioItems + "/3";
        if (hasAntenna && hasHeadPhones && hasRadio) StartCoroutine(enumerator());
    }

    public void sethasRadio(bool radio)
    {
        hasRadio = radio;
        radioItems++;
        radioText.text = radioItems + "/3";
        if (hasAntenna && hasHeadPhones && hasRadio) StartCoroutine(enumerator());
    }

    IEnumerator enumerator()
    {
        doorScriptLocked.setCantLeaveWithoutRadio(true);
        doorScriptLocked2.setCantLeaveWithoutRadio(true);
        yield return new WaitForSeconds(2);
        radio.text = "Now I have everything for the radio";
        yield return new WaitForSeconds(3);
        radio.text = "";
        yield return new WaitForSeconds(1);
        radio.text = "I should now head to my cabbin to call for help !";
        yield return new WaitForSeconds(5);
        radio.text = "";
        radioText.text = "";
        objective.text = "Objective: Head back to cabbin and setup the radio";
    }
}
