using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGravity : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;

    [SerializeField] private float[] gravityValues;
    [SerializeField] private float loopTime;
    private void Awake()
    {
        StartCoroutine(GravityLoop());
    }

    IEnumerator GravityLoop()
    {
        for (int i = 0; i < gravityValues.Length; i++)
        {
            particleSystem.gravityModifier = gravityValues[i];
            yield return new WaitForSeconds(loopTime);
        }

        yield return null;
    }
}
