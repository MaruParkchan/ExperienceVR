using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissovleLoop : MonoBehaviour
{
    [SerializeField] private Color colors;
    [SerializeField] private float speed;
    [SerializeField] private bool fadeIn;
    private MeshRenderer render;
    [SerializeField] private float dissolve = 0;
    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
        StartFade();
    }

    private void StartFade()
    {
        if (fadeIn)
        {
            StartCoroutine(FadeIn());
        }
        else
        {
            StartCoroutine(FadeOut());
        }
    }

    private void Update()
    {
        render.material.SetFloat("DissovleValue", dissolve);
    }

    IEnumerator FadeIn()
    {
        dissolve = 1.0f;
        while(true)
        {
            if (dissolve <= -1.0f)
            {
                dissolve = -1.0f;
                yield break;
            }

            dissolve -= speed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        dissolve = -1.0f;
        while (true)
        {
            if (dissolve >= 1.0f)
            {
                dissolve = 1.0f;
                yield break;
            }

            dissolve += speed * Time.deltaTime;
            yield return null;
        }
    }

    private void OnEnable()
    {
        StartFade();
    }
}
