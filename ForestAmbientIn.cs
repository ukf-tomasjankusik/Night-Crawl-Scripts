using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAmbientIn : MonoBehaviour
{
    public DeepDarkAmbient DDA;
    public ForestAmbientOut forestAmbientOut;


    private void OnTriggerEnter(Collider other)
    {
        //(AudioSource audioSource, float duration, float targetVolume)
        StartCoroutine(FadeAudioSource.StartFade(forestAmbientOut.getAudioSource(), 0.6f, 0f));
        StartCoroutine(FadeAudioSource.StartFade(DDA.GetComponent<AudioSource>(), 0.6f, 0.3f));
    }



}
