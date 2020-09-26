using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailGame : MonoBehaviour
{
    [SerializeField] private Trace tarceSysytem;

    private void OnEnable()
    {
        tarceSysytem.StartRailGame();
    }
}
