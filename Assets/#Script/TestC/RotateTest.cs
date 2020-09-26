using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    [SerializeField] Vector3 pos;


    private void Update()
    {
        transform.Rotate(pos);
    }
}
