using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSystem : MonoBehaviour
{
    [SerializeField] private GameObject fadeImage;

    public void FadeImageSetActive()
    {
        fadeImage.SetActive(true);
    }
}
