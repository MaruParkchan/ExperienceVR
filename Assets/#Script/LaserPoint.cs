using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    [SerializeField] private GameStartHit gameStartHit;
    private HowTo howTo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("StartHit"))
        {
            gameStartHit = other.GetComponent<GameStartHit>();
        }

        if(other.transform.CompareTag("HowTo"))
        {
            Debug.Log("Enter");
            howTo = other.GetComponent<HowTo>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("StartHit"))
        {
            gameStartHit = null;
        }

        if(other.transform.CompareTag("HowTo"))
        {
            howTo = null;
        }
    }

    public void IsClick()
    {
        if (gameStartHit == null)
            return;

        gameStartHit.StartGame();        
    }

    public void HowToClick()
    {
        if (howTo == null)
            return;

        howTo.NextPage();
    }

}
