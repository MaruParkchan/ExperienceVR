using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInput : MonoBehaviour
{
    [SerializeField] private SteamVR_Input_Sources handType;
    [SerializeField] private SteamVR_Action_Boolean pinchButton;
    [SerializeField] private SteamVR_Action_Boolean gripButton;
    [SerializeField] private SteamVR_Action_Boolean teleportButton;

    private GameObject player;
    private Movement movement;
    [SerializeField] private LaserPoint laserPoint;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Start()
    {
        movement = player.GetComponent<Movement>();
    }

    private void Update()
    {
        if(GetButtonDown(pinchButton))
        {
            laserPoint.IsClick();
            laserPoint.HowToClick();
        }

        //if (GetButtonDown(gripButton))
        //{
        //    Debug.Log("옆 버튼");
        //}


        if (GetButtonDown(teleportButton) && movement.GetMoveFreeze() == false)
        {
            PlayerMoveTo(true);
        }

        else if (GetButtonUp(teleportButton) && movement.GetMoveFreeze() == false)
        {
            PlayerMoveTo(false);
        }
    }

    private bool GetButtonDown(SteamVR_Action_Boolean button)
    {
        return button.GetStateDown(handType);
    }

    private bool GetButtonUp(SteamVR_Action_Boolean button)
    {
        return button.GetStateUp(handType);
    }

    private void PlayerMoveTo(bool isMove)
    {
        movement.Move(isMove);
    }
}
