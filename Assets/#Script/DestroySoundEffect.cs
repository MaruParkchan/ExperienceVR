using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip soundClip;
    [SerializeField] private GameObject soundEffect;
    [SerializeField] private GameObject effectObject;
    [SerializeField] private string tagName;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(tagName))
        {
            SoundPlay();
            EffectSpawn();
            Destroy(this.gameObject);
        }
    }

    private void SoundPlay()
    {
        GameObject clone = Instantiate(soundEffect);
        clone.GetComponent<SoundEffect>().SoundPlay(soundClip);
    }

    private void EffectSpawn()
    {
        GameObject clone = Instantiate(effectObject);
        clone.transform.position = transform.position;
    }
}
