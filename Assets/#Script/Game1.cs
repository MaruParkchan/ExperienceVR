using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Game1 : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] TextMeshProUGUI playCountDownText;
    [Header("수")]
    [SerializeField] float spawnCycleTime;
    [SerializeField] private float gamePlayTimer;
    private float basePlayTimer;
    [Header("몬스터프리팹")]
    [SerializeField] GameObject dudeogeObject;
    [SerializeField] GameObject rainbowDudeogeObject;
    [Header("스폰위치들")]
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] boxObjects;
    [SerializeField] Transform[] objectSpawnPoints;
    private int spawnPointIndex;
    private bool isGameEnd = false;

    private void Awake()
    {
        basePlayTimer = gamePlayTimer;
    }

    private void Update()
    {
        if(gamePlayTimer <= 0)
        {
            isGameEnd = true;
            gameSystem.EndGame();
            scoreSystem.GameEnd(true);
            scoreSystem.GameEndScore();
            this.gameObject.SetActive(false);
            return;
        }

        gamePlayTimer -= Time.deltaTime;
        playCountDownText.text = "남은시간\n" + (int)gamePlayTimer; 
        ObjectBoxReSpawn();
    }
    IEnumerator LoopGame()
    {      
        while(true)
        {
            if (isGameEnd)
                yield break;

            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject clone = Instantiate(dudeogeObject);
            clone.GetComponent<Game1Enemy>().DestroyTime(spawnCycleTime);
            clone.transform.position = spawnPoints[spawnPointIndex].position + new Vector3(0,0.2f,0);
            yield return new WaitForSeconds(spawnCycleTime);

        }      
    }

    private void ObjectBoxReSpawn()
    {
        for (int i = 0; i < boxObjects.Length; i++)
        {
            if (boxObjects[i].activeSelf == false)
            {
                GameObject clone = boxObjects[i];
                clone.SetActive(true);
                clone.transform.position = objectSpawnPoints[i].position;
                clone.transform.rotation = Quaternion.identity;
            }
        }
    }

    private void OnEnable()
    {
        gamePlayTimer = basePlayTimer;
        scoreSystem.GameEnd(false);
        isGameEnd = false;
        StartCoroutine(LoopGame());
    }
}
