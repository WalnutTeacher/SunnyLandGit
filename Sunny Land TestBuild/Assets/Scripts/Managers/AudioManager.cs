using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _AudioManager = null;

    AudioSource _AudioSource;

    // BGM
    [Header("BGM")]
    public AudioClip main;
    public AudioClip run;

    // SE
    [Header("SE")]
    public AudioClip page;
    public AudioClip clear;
    public AudioClip scoreUp;

    // PLAYER
    public AudioClip jump;
    public AudioClip fallDown;

    // ITEM
    public AudioClip getItem;

    // ENEMY
    public AudioClip ppyong;

    void Awake()
    {
        if (_AudioManager == null)
        {
            _AudioManager = this;
        }
        else if (_AudioManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // BGM
    public void BGM_Main()
    {
        _AudioSource.clip = main;
        _AudioSource.Play();
    }

    public void BGM_Run()
    {
        _AudioSource.clip = run;
        _AudioSource.Play();
    }

    public void BGM_Stop()
    {
        _AudioSource.Stop();
    }

    public void BGM_Volume(float volume)
    {
        _AudioSource.volume = volume;
    }

    // SE
    public void SE_Page()
    {
        _AudioSource.PlayOneShot(page);
    }

    public void SE_Clear()
    {
        _AudioSource.PlayOneShot(clear);
    }

    public void SE_ScoreUp()
    {
        _AudioSource.PlayOneShot(scoreUp);
    }

    public void SE_Jump()
    {
        _AudioSource.PlayOneShot(jump);
    }

    public void SE_FallDown()
    {
        _AudioSource.PlayOneShot(fallDown);
    }

    public void SE_GetItem()
    {
        _AudioSource.PlayOneShot(getItem);
    }

    public void SE_Ppyong()
    {
        _AudioSource.PlayOneShot(ppyong);
    }
}
