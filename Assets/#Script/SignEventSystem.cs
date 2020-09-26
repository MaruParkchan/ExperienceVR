using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignEventSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] signObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            for (int i = 0; i < signObject.Length; i++)
                signObject[i].SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            for (int i = 0; i < signObject.Length; i++)
                signObject[i].SetActive(false);
        }
    }
}
