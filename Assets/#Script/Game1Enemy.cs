using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Enemy : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;

    private ScoreSystem game1ScoreData;

    private void Awake()
    {
        game1ScoreData = GameObject.FindWithTag("Game1Score").GetComponent<ScoreSystem>();   
    }

    public void DestroyTime(float time)
    {
        Destroy(this.gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Box"))
        {
            game1ScoreData.PlusScore(1);
            GameObject clone = Instantiate(hitEffect);
            clone.transform.position = transform.position;
            other.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
