using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private Player player;
    private Movement playerMovement;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject fadeInOutObject;
    [SerializeField] private GameObject countObject;
    [SerializeField] private bool isMoveFreezeCheck;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerMovement = GameObject.FindWithTag("Player").GetComponent<Movement>();
    }

    public void StartGame()
    {
        //if (player.GetIsPlayingGame() == true)
        //    return;

        StartCoroutine(IStartGame());
    }

    public void EndGame()
    {
        StartCoroutine(IEndGame());
    }

    IEnumerator IStartGame()
    {
       // player.IsPlayerGame(true); // Player 게임
        MoveLock();
        fadeInOutObject.SetActive(true); // 페이드아웃 활성화
        yield return new WaitForSeconds(0.2f); 
        player.transform.position = startPoint.position;
        yield return new WaitForSeconds(0.5f);
        fadeInOutObject.SetActive(false);
        countObject.SetActive(true);
    }

    IEnumerator IEndGame()
    {
        yield return new WaitForSeconds(1.0f);
        countObject.SetActive(false);
        fadeInOutObject.SetActive(true); // 페이드아웃 활성화
        yield return new WaitForSeconds(0.2f);
        MoveLockClear();
        player.transform.position = endPoint.position;
        yield return new WaitForSeconds(0.5f);
      //  player.IsPlayerGame(false);
        fadeInOutObject.SetActive(false);
    }

    private void MoveLock() // 움직임을 잠금
    {
        if(isMoveFreezeCheck == true)
        {
            playerMovement.IsFreezeMove(true);
        }
    }

    private void MoveLockClear()
    {
        playerMovement.IsFreezeMove(false);
    }
}
