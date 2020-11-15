using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    public static Fader instance;

    Animator animator;
    public event Action storedFunc;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Fader exists!");
            Destroy(this.transform.root.gameObject);
        }

        instance = this;
        animator = GetComponent<Animator>();
        DontDestroyOnLoad(this.transform.root.gameObject);
    }

    public AudioSource audio;
    float currentMusicTime;
 
    void Update()
    {
        currentMusicTime = audio.time;
    }

    private void OnLevelWasLoaded(int level)
    {
        audio.time = currentMusicTime;
    }


    private void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void FadeOut()
    {
        animator.ResetTrigger("FadeOut");
        animator.ResetTrigger("FadeIn");
        animator.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        animator.ResetTrigger("FadeOut");
        animator.ResetTrigger("FadeIn");
        animator.SetTrigger("FadeIn");
    }

    public void CallStoredFunc()
    {
        if (storedFunc != null)
        {
            storedFunc();
            FadeIn();
        }
    }
}
