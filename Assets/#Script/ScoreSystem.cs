using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI currentscoreText; 
    [SerializeField] private string gameScoreName;
    private int currentScore = 0;
    private bool isGameEnd;

    private void Awake()
    {
        bestScoreText.text = "최고점수\n" + PlayerPrefs.GetInt(gameScoreName);
        currentscoreText.text = "현재점수 : " + currentScore;
    }

    public void PlusScore(int score)
    {
        if (isGameEnd)
            return;

        currentScore += score;
        currentscoreText.text = "현재점수 : " + currentScore;
    }

    public void GameEndScore()
    {
        if (PlayerPrefs.GetInt(gameScoreName) <= currentScore)
        {
            PlayerPrefs.SetInt(gameScoreName, currentScore);
        }

        currentScore = 0;
        StartCoroutine(ScoreReset());
    }

    public void GameEnd(bool isEnd)
    {
        isGameEnd = isEnd;
    }

    IEnumerator ScoreReset()
    {
        yield return new WaitForSeconds(1.9f);
        currentscoreText.text = "현재점수 : " + currentScore;
        bestScoreText.text = "최고점수\n" + PlayerPrefs.GetInt(gameScoreName);
    }
}
