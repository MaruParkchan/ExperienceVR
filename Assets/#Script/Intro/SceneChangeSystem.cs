using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeSystem : MonoBehaviour
{
    [SerializeField] private string changeSceneName;

    public void ChangeScene()
    {
        SceneManager.LoadScene(changeSceneName);
    }
}
