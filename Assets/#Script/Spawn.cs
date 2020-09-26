using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject clones;

    private void Awake()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        while(true)
        {
            GameObject clone = Instantiate(clones);
            clone.transform.position = this.transform.position;

            yield return new WaitForSeconds(1.0f);

            yield return null;
        }
    }
}
