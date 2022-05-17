using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
#if UNITY_EDITOR
    public int num;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            num++;
            ScreenCapture.CaptureScreenshot("ScreenShot" + num + ".png");
            Debug.Log("스크린샷저장");
        }
    }
#endif
}
