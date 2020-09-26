using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float xPos;
    private float yPos;
    private float zPos;

    private void Awake()
    {
        xPos = Random.Range(-2, 2);
        yPos = Random.Range(-2, 2);
        zPos = Random.Range(-2, 2);
}

    private void FixedUpdate()
    {
        transform.Rotate(xPos, yPos, zPos);
    }
}
