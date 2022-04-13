using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monolog2 : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        text.GetComponent<Text>();
        text.alignment = TextAnchor.LowerCenter;
        text.fontSize = 27;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(enumerator());
        }
    }

    IEnumerator enumerator()
    {
        text.text = "This is INSANE!";
        yield return new WaitForSeconds(2.5f);
        text.text = "";
        gameObject.SetActive(false);
    }

}
