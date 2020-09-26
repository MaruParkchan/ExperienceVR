using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEvent : MonoBehaviour
{

    [SerializeField] private GameObject[] eventOnObjects;

    [SerializeField] private string tagName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(tagName))
        {
            Debug.Log("Ok");
            for (int i = 0; i < eventOnObjects.Length; i++)
            {
                eventOnObjects[i].SetActive(true);
            }
        }
    }
}
