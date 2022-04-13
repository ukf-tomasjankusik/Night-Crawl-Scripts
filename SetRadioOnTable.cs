using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRadioOnTable : MonoBehaviour
{
    bool enterOnce = true;
    public Text radio;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enterOnce)
        {
            StartCoroutine(enumeratorSetRadioOnTable());
        }
    }

    IEnumerator enumeratorSetRadioOnTable()
    {       
        enterOnce = false;
        radio.text = "Let´s set this radio on the table in the kitchen";
        yield return new WaitForSeconds(3);
        radio.text = "";
        gameObject.SetActive(false);
    }

}
