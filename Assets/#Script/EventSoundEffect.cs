using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSoundEffect : MonoBehaviour
{
    private AudioSource audioSound;

    private void Awake()
    {
        audioSound = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            audioSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
            audioSound.Stop();
    }
}
