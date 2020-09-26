using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTo : MonoBehaviour
{
    [SerializeField] private GameObject[] howToList = new GameObject[3];
    private int index;
    public void NextPage()
    {
        howToList[index].SetActive(false);

        if (index >= 2)
            return;

        index++;
        howToList[index].SetActive(true);
    }
}
