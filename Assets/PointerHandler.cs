using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class PointerHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    [SerializeField] IntroSystem introSystem;

    void Start()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerInside(object sender, PointerEventArgs eventArgs)
    {
        if (eventArgs.target.CompareTag("UI"))
        {
            Debug.Log("UI Inside");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs eventArgs)
    {
        if (eventArgs.target.CompareTag("UI"))
        {
            Debug.Log("UI Outside");
        }
    }

    public void PointerClick(object sender, PointerEventArgs eventArgs)
    {
        if (eventArgs.target.CompareTag("UI"))
        {
            Debug.Log(eventArgs.target.name);
            introSystem.FadeImageSetActive(); // 페이드 이미지 활성화
        }
    }
}
