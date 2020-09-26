using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Game2 : MonoBehaviour
{
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameSystem gameSystem;
    [SerializeField] private TextMeshProUGUI hpCurrentText;
    [SerializeField] private GameObject[] boxClones;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float boxSpawnTime;
    private int hp = 3;
    private bool isDie = false;
    private int enemyIndex;

    public void TakeDamage()
    {
        if (isDie)
            return;

        hp--;
        hpCurrentText.text = "남은 생명\n" + hp;
        if (hp <= 0 && isDie == false)
        { 
            isDie = true;
            GameObject[] clones = GameObject.FindGameObjectsWithTag("G2Box");

            for (int i = 0; i < clones.Length; i++)
                Destroy(clones[i].transform.gameObject);

            gameSystem.EndGame();
            scoreSystem.GameEnd(true);
            scoreSystem.GameEndScore();
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator BoxSpawn()
    {
        WaitForSeconds loopTime = new WaitForSeconds(boxSpawnTime);
        while(true)
        {
            if (isDie)
            {
        //        this.gameObject.SetActive(false);
                yield break;
            }

            enemyIndex = Random.Range(0, 2);
            GameObject clone = Instantiate(boxClones[enemyIndex]);
            clone.transform.position = startPoint.position;
            yield return loopTime;
        }
    }
    
    private void OnEnable()
    {
        hpCurrentText.text = "남은 생명\n" + hp;
        hp = 3;
        isDie = false;
        StartCoroutine(BoxSpawn());
    }
}
  