using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAmbientOut : MonoBehaviour
{
    public AudioSource AS;
    public DeepDarkAmbient DDA;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //(AudioSource audioSource, float duration, float targetVolume)
        StartCoroutine(FadeAudioSource.StartFade(AS, 0.6f, 1.5f));
        StartCoroutine(FadeAudioSource.StartFade(DDA.GetComponent<AudioSource>(), 0.6f, 0f));
    }

    public AudioSource getAudioSource()
    {
        return AS;
    }
}
