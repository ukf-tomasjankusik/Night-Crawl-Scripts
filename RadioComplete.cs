using Ladder.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RadioComplete : MonoBehaviour
{
    public Text radio;
    public Text objective;
    public PointLight pointLight1;
    public PointLight pointLight2;
    public ZombieEnd zombie2;
    public FirstPersonController FPScontroller;
    public InteractUI Candle;

    IEnumerator enumeratorFinal()
    {
        objective.text = "";
        Destroy(Candle.gameObject);
        FPScontroller.GetComponent<Animator>().SetBool("isEnd", true);
        FPScontroller.GetComponent<Animator>().enabled = true;
        FPScontroller.GetComponent<FirstPersonController>().enabled = false;
        
        yield return new WaitForSeconds(3);
        radio.text = "Is it working??";
        yield return new WaitForSeconds(2);
        radio.text = "";
        yield return new WaitForSeconds(2);
        pointLight2.PlaySound();
        pointLight2.LightSmash();         
        yield return new WaitForSeconds(0.4f);
        radio.text = "What was that?!";
        FindObjectOfType<PlayerAudioManager>().Play("HeartBeat");
        yield return new WaitForSeconds(2);
        radio.text = "";
        yield return new WaitForSeconds(7.6f);
        pointLight1.PlaySound();
        pointLight1.LightSmash();
        radio.text = "What is hapenning?!";
        yield return new WaitForSeconds(2);
        radio.text = "";
        yield return new WaitForSeconds(0.5f);
        radio.text = "Hello?! Can anyone hear me?!";
        yield return new WaitForSeconds(3);
        radio.text = "";
        zombie2.gameObject.SetActive(true);
        yield return new WaitForSeconds(9.47f);
        FindObjectOfType<PlayerAudioManager>().Play("JumpScareFinal");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameWin");

    }

    public void StartEnumerator()
    {
        StartCoroutine(enumeratorFinal());
    }



}
