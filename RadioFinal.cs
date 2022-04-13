using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioFinal : MonoBehaviour
{
    bool enter = false;
    bool radioFinalGUIOnce = true; //ensure we can use the end event only once
    public Text radio;
    public RadioComplete radioComplete;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = false;
        }
    }

    void OnGUI()
    {
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 200, 30), "Press 'F' to setup the radio");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && enter && radioFinalGUIOnce)
        {
            radioFinalGUIOnce = false;
            radioComplete.gameObject.SetActive(true);
            radioComplete.StartEnumerator();
            gameObject.SetActive(false);
        }
    }






}
