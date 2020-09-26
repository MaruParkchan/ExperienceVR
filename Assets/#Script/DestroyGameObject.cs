using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] private float timer;

    private void Awake()
    {
        Destroy(this.gameObject, timer);
    }
}
