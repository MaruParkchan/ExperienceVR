using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Box : MonoBehaviour
{
    [SerializeField] private GameObject successEffect;
    [SerializeField] private GameObject failEffect;

    [Header("TagNames")]
    [SerializeField] private string successTileName;
    [SerializeField] private string[] failTileName = new string[2];
    private Game2 game2System;
    private ScoreSystem scoreSystem;
    [Header("사운드")]
    [SerializeField] private GameObject soundEffect;
    [SerializeField] private AudioClip destroySoundClip;

    private void Awake()
    {
        game2System = GameObject.FindWithTag("Game2").GetComponent<Game2>();
        scoreSystem = GameObject.FindWithTag("Game2Score").GetComponent<ScoreSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(successTileName))
        {
            SuccessEvent();
        }

        if(other.transform.CompareTag(failTileName[0]) || other.transform.CompareTag(failTileName[1]))
        {
            FailEvent();
        }

        if (other.transform.CompareTag("DestroyPlane"))
        {
            Debug.Log("aa");
            SoundPlay();
        }
    }

    private void SuccessEvent()
    {
        SoundPlay();
        GameObject clone = Instantiate(successEffect);
        clone.transform.position = transform.position;
        scoreSystem.PlusScore(1);
        Destroy(this.gameObject);
    }

    private void FailEvent()
    {
        SoundPlay();
        GameObject clone = Instantiate(failEffect);
        clone.transform.position = transform.position;
        game2System.TakeDamage();
        Destroy(this.gameObject);
    }

    private void SoundPlay()
    {
        GameObject clone = Instantiate(soundEffect);
        clone.GetComponent<SoundEffect>().SoundPlay(destroySoundClip);
    }
}
