using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game3 : MonoBehaviour
{
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameSystem gameSystem;
    [SerializeField] private TextMeshProUGUI hpCurrentText;
    [SerializeField] private GameObject[] enemys;
    [SerializeField] private Transform[] spawnLists;
    [SerializeField] private float enemySpawnTime;

    [Header("오브젝트끄기")]
    [SerializeField] GameObject stickLeft;
    [SerializeField] GameObject stickRight;
    [SerializeField] GameObject swordLeft;
    [SerializeField] GameObject swordRight;

    private int hp = 3;
    private bool isDie = false;
    private int enemyIndex;
    private int enemySpawnPointIndex;


    public void TakeDamage()
    {
        if (isDie)
            return;

        hp--;
        hpCurrentText.text = "남은 생명\n" + hp;
        if (hp <= 0 && isDie == false)
        {
            isDie = true;
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Game3Enemy");

            for (int i = 0; i < clones.Length; i++)
                Destroy(clones[i].transform.gameObject);

            gameSystem.EndGame();
            scoreSystem.GameEnd(true);
            scoreSystem.GameEndScore();
            SwordOff();
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator EnemySpawn()
    {
        WaitForSeconds loopTime = new WaitForSeconds(enemySpawnTime);
        WaitForSeconds firstDelay = new WaitForSeconds(1.5f);
        while (true)
        {
            if (isDie)
                yield break;

            yield return firstDelay;
            enemyIndex = Random.Range(0, enemys.Length);
            enemySpawnPointIndex = Random.Range(0, spawnLists.Length);
            GameObject clone = Instantiate(enemys[enemyIndex]);
            clone.transform.position = spawnLists[enemySpawnPointIndex].position;
            yield return loopTime;
        }
    }

    private void OnEnable()
    {
        hp = 3;
        isDie = false;
        hpCurrentText.text = "남은 생명\n" + hp;
        SwordOn();
        StartCoroutine(EnemySpawn());
    }

    private void SwordOn()
    {
        stickLeft.SetActive(false);
        stickRight.SetActive(false);
        swordLeft.SetActive(true);
        swordRight.SetActive(true);
    }

    private void SwordOff()
    {
        stickLeft.SetActive(true);
        stickRight.SetActive(true);
        swordLeft.SetActive(false);
        swordRight.SetActive(false);
    }
}
