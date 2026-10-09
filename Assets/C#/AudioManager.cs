using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField]private AudioSource musicSource;
    [SerializeField]private AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip _bgm;
    public AudioClip death;
    public AudioClip portalIn;
    public AudioClip portalOut;
    
    void Awake()
    {

        musicSource.clip = _bgm;
        musicSource.Play();
    }

}
