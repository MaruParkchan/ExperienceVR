using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEventSystem : MonoBehaviour
{
    [SerializeField] private GameObject uiImageObject;
    [SerializeField] private GameObject laserPointObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            laserPointObject.SetActive(true);
            uiImageObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            laserPointObject.SetActive(false);
            uiImageObject.SetActive(false);
        }
    }
}
