using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveObject : MonoBehaviour
{
    [SerializeField] private GameObject effect;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            GameObject clone = Instantiate(effect);
            clone.transform.position = transform.position;
            this.gameObject.SetActive(false);
        }
    }
}
