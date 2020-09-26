using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject effectObject;
    [SerializeField] private string targetTagName;


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(targetTagName))
        {
            GameObject clone = Instantiate(effectObject);
            clone.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(targetTagName))
        {
            GameObject clone = Instantiate(effectObject);
            clone.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }

}
