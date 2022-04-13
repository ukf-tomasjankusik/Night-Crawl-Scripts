using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microphone : MonoBehaviour
{
    public RadioScript radioScript;
    bool enter = false;

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
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 50), "Press 'F' to pickup the microphone");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && enter)
        {
            FindObjectOfType<PlayerAudioManager>().Play("Interaction");
            radioScript.setHasHeadphones(true);
            gameObject.SetActive(false);
        }
    }
}
