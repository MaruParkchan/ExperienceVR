using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] SteamVR_Input_Sources handType;
  //  [SerializeField] SteamVR_Behaviour_Pose controllerPose;
    [SerializeField] SteamVR_Action_Boolean gripButton;

    [SerializeField] GameObject controllerObject;
    [SerializeField] GameObject swordObject;
    private void Update()
    {
        if(GetButtonDown(gripButton))
        {
            controllerObject.SetActive(false);
            swordObject.SetActive(true);
        }

        if (GetButtonUp(gripButton))
        {

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            Debug.Log("Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("Exit");
        }
    }
}
