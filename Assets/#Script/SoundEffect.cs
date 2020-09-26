using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource audioSound;

    private void Awake()
    {
        audioSound = GetComponent<AudioSource>();        
    }

    public void SoundPlay(AudioClip clip)
    {
        audioSound.clip = clip;

        audioSound.Play();
    }
}
