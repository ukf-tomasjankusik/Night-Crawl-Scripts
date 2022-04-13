using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSwitcher : MonoBehaviour
{
    bool hasCandle = false;
    bool switchCandle = false;
    public InteractUI interactUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasCandle)
        {
            if (switchCandle)
            {
                interactUI.gameObject.SetActive(true);
                FindObjectOfType<PlayerAudioManager>().Play("Candle");
            }
            else 
            {
                interactUI.gameObject.SetActive(false);
                FindObjectOfType<PlayerAudioManager>().Play("CandleExtinguish");
            }
           
            switchCandle = !switchCandle;
        }
    }

    public void setHasCandle(bool candle)
    {
        hasCandle = candle;
    }
}
