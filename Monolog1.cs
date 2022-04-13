using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monolog1 : MonoBehaviour
{
    public Text text;
    public Text objective;

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
        text.text = "I need to find all radio components before I leave";
        yield return new WaitForSeconds(5);
        text.text = "";
        objective.text = "Objective: find all required radio components";
        gameObject.SetActive(false);
    }




}
