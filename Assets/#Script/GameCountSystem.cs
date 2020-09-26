using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCountSystem : MonoBehaviour
{
    [SerializeField] private GameObject TargetGameSystemObject;

    private TextMeshProUGUI countText;

    private float timer = 3.9f;

    private void Awake()
    {
        countText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (timer <= 0)
        {
            TargetGameSystemObject.SetActive(true);
            this.gameObject.SetActive(false);
            return;
        }
        timer -= Time.deltaTime;
        countText.text = "" + (int)timer;
    }

    private void OnEnable()
    {
        timer = 3.9f;
    }

}
