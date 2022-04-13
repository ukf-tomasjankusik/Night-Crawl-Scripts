using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : MonoBehaviour
{
    public InteractUI interactUI;  // Player candle
    public SC_DoorScriptCandle DoorCandle;
    bool enter = false;
    bool switchCandle = true;
    bool hasCandle = false;
    public CandleSwitcher candleSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
        }


    }

    private void OnTriggerExit(Collider other)
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
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to pickup candle");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && enter)
        {
            DoorCandle.setHasCandle(true);
            candleSwitcher.setHasCandle(true);
            interactUI.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }



}
