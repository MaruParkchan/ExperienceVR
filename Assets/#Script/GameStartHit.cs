using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartHit : MonoBehaviour
{
    [SerializeField] GameSystem gameSystem;

    public void StartGame()
    {
        Debug.Log("클릭");
        gameSystem.StartGame();
    }
}
