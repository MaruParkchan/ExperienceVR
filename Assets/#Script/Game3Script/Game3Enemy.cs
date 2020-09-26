using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Enemy : MonoBehaviour
{
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private GameObject playerHitEffect;
    [SerializeField] private float speed;
    [SerializeField] private GameObject soundEffect;
    [SerializeField] private AudioClip dieSoundClip;
    private Game3 game3System;
    private ScoreSystem scoreSystem;
    private GameObject target;

    private void Awake()
    {
        game3System = GameObject.FindWithTag("Game3").GetComponent<Game3>();
        scoreSystem = GameObject.FindWithTag("Game3Score").GetComponent<ScoreSystem>();
        target = GameObject.FindWithTag("Game3Hit");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Game3Hit"))
        {
            PlayerHit();
        }


        if(other.transform.CompareTag("Sword"))
        {
            Die();
        }
    }

    private void PlayerHit()
    {
        GameObject clone = Instantiate(playerHitEffect);
        clone.transform.position = transform.position;
        game3System.TakeDamage();
        Destroy(this.gameObject);
    }

    private void Die()
    {
        DieSoundPlay();
        GameObject clone = Instantiate(dieEffect);
        clone.transform.position = transform.position;
        scoreSystem.PlusScore(1);
        Destroy(this.gameObject);
    }

    private void DieSoundPlay()
    {
        GameObject clone = Instantiate(soundEffect);
        clone.GetComponent<SoundEffect>().SoundPlay(dieSoundClip);
    }
}