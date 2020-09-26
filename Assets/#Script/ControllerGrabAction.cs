using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ControllerGrabAction : MonoBehaviour
{
    [SerializeField] SteamVR_Input_Sources handType;
    [SerializeField] SteamVR_Behaviour_Pose controllerPose;
    [SerializeField] SteamVR_Action_Boolean grabPinchAction;

    private GameObject collidingObject; // 충돌중인 객체
    private GameObject objectInHand; // 플레이어가 잡은 객체

    private void Update()
    {
        if(GetButtonDown(grabPinchAction))
        {
           if(collidingObject)
            {
                GrabObject();
            }
        }

        if (GetButtonUp(grabPinchAction))
        {
            if (collidingObject)
            {
                ReleaseObject();
            }
        }
    }

    private void SetCollidingObject(Collider col) // 충돌객체 설정
    {
        if(collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }
    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
       // if( ----------- )   ->  테스트 - 현재 게임2 박스 체크 및 메소드 안에 bool check 
       // objectInHand.GetComponent<Box>(). 
    }
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
    private void ReleaseObject()
    {
        if(GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }

        objectInHand = null;
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
        SetCollidingObject(other);
    }
    private void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if(!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }


}
