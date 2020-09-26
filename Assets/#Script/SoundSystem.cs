using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip mainSoundClip; //메인 사운드
    [SerializeField] private AudioClip mineSoundClip; //광산 사운드 

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SoundMinePlay()
    {
        audioSource.Stop();
        audioSource.clip = mineSoundClip;
        audioSource.Play();
    }

    public void SounMainPlay() 
    {
        audioSource.Stop();
        audioSource.clip = mainSoundClip;
        audioSource.Play();
    }
}
