using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour
{
    public AudioSource AS;
    public Light light;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
        light = GetComponent<Light>();
    }

    public void PlaySound()
    {
        AS.Play();
    }

    public void LightSmash()
    {
        light.intensity = 0;
    }

}
