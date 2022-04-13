using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepDarkAmbient : MonoBehaviour
{
    public AudioSource aS1;

    private void Start()
    {
        aS1 = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //(AudioSource audioSource, float duration, float targetVolume)
            StartCoroutine(FadeAudioSource.StartFade(aS1, .4f, .5f)); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //(AudioSource audioSource, float duration, float targetVolume)
            StartCoroutine(FadeAudioSource.StartFade(aS1, .4f, .3f)); 
        }
    }

    public void ChangeAudio(float audioVolume)
    {
        StartCoroutine(FadeAudioSource.StartFade(aS1, .4f, audioVolume));
    }

}
