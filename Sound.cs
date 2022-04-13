using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    [Range(0f, 1f)]
    public float spatialBlend;
    [Range(0f, 100f)]
    public float maxDistance;
    [Range(0f, 100f)]
    public float minDistance;
    [Range(0f, 1f)]
    public float dopplerLevel;
    public bool loop;
    public bool playOnAwake;
    public AudioRolloffMode rolloffMode;
    


    [HideInInspector]
    public AudioSource source;

}
