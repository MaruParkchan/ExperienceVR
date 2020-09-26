using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToBound : MonoBehaviour
{
    [SerializeField] private GameObject laserPointObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            laserPointObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            laserPointObject.SetActive(false);
        }
    }
}
