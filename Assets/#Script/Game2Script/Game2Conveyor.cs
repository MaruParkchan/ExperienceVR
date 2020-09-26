using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Conveyor : MonoBehaviour
{
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed;

    private void OnTriggerStay(Collider other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
    }
}
