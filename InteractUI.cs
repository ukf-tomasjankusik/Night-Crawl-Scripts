using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ladder.Scripts;

public class InteractUI : MonoBehaviour
{
    bool switchCandle = true;
    bool hasCandle = true; 
    bool FinalBool = true;
    public VHSMode camera;
    public float smooth = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasCandle)
        {
            if (switchCandle) gameObject.SetActive(true);
            else gameObject.SetActive(false);
            switchCandle = !switchCandle;

        }

        transform.rotation = Quaternion.Slerp(transform.rotation, camera.transform.rotation , Time.deltaTime * smooth);

    }

    public void setHasCandle(bool candle)
    {
        hasCandle = candle;
    }

}
