using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class ZombieAudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static ZombieAudioManager instance;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
            s.source.maxDistance = s.maxDistance;
            s.source.minDistance = s.minDistance;
            s.source.loop = s.loop;
            s.source.rolloffMode = s.rolloffMode;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }



    void Update()
    {
        gameObject.transform.position = GameObject.Find("Zombie1").transform.position;
    }
}
