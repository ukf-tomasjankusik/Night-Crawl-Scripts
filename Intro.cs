using Ladder.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public Text IntroText;
    public Text SkipIntroText;
    public RenderTexture renderTexture;
    public FirstPersonController FPScontroller;
    public ZombieNavMesh Zombie;
    public DeepDarkAmbient DDA;
    public AudioSource AS;
    public Camera cam;
    bool VHSModeBool = false;
    public GameObject CanvasVHS;
    public AudioListener audioListener;
    public GameObject CandlePath;


    public GameObject loadingScreen;
    public Slider slider;

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }


    }


    private void Start()
    {
        cam = GetComponent<Camera>();
        cam.farClipPlane = PlayerPrefs.GetFloat("renderDistance");
        DDA.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        IntroText.GetComponent<Text>();
        SkipIntroText.GetComponent<Text>();
        IntroText.alignment = TextAnchor.LowerCenter;
        IntroText.fontSize = 27;
        SkipIntroText.alignment = TextAnchor.LowerCenter;
        SkipIntroText.fontSize = 20;
        AS = GetComponent<AudioSource>();
        AS.Play();
        StartCoroutine(enumerator());
    }


    IEnumerator enumerator()
    {
        SkipIntroText.text = "Press SPACE to skip intro";
        yield return new WaitForSeconds(5);
        SkipIntroText.text = "";
        yield return new WaitForSeconds(1);
        IntroText.text = "My name is Joseph Scott, I live in this cabbin over here";
        yield return new WaitForSeconds(8);
        IntroText.text = "";
        yield return new WaitForSeconds(1);
        IntroText.text = "I always wanted to live in the forest";
        yield return new WaitForSeconds(8);
        IntroText.text = "But one thing here was always scary for me";
        yield return new WaitForSeconds(8);
        IntroText.text = "And it was this big house that was here before I moved here";
        yield return new WaitForSeconds(10);
        IntroText.text = "One day, I was not able to find my radio";
        yield return new WaitForSeconds(8);
        IntroText.text = "And the only one who could steal it, had to live in there";
        yield return new WaitForSeconds(8);
        IntroText.text = "So one day, I approached to that house, to see if I can get any response";
        yield return new WaitForSeconds(8);
        IntroText.text = "Didn´t know it was the biggest mistake I could ever make!";
        yield return new WaitForSeconds(8);
        IntroText.text = "All I remember, is that I was hit by someone from behind";
        yield return new WaitForSeconds(8);
        IntroText.text = "And then I woke up in the miserable place";
        yield return new WaitForSeconds(8);
        IntroText.text = "And here I am now";
        yield return new WaitForSeconds(6);
        Load();   
    }

    void Load()
    {
        AS.Stop();
        audioListener.enabled = false;
        //  DDA.gameObject.SetActive(true);
        //  FPScontroller.gameObject.SetActive(true);
        //   CandlePath.gameObject.SetActive(true);
        //   Zombie.ZombieFootstepsTurnOn();
        //   Zombie.StartLookForPlayer();
        LoadLevel("SampleScene");
        gameObject.SetActive(false); 
    }


    public void changeVHSMode()
    {
        VHSModeBool = !VHSModeBool;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Load();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            changeVHSMode();
            if (VHSModeBool) 
            {
                CanvasVHS.SetActive(true);
                cam.targetTexture = (RenderTexture)GameObject.Find("CanvasVHS").GetComponentInChildren<RawImage>().mainTexture;
                
                
            } 
            else
            {
                cam.targetTexture = null;
                CanvasVHS.SetActive(false);
            }
        }

    }
}
