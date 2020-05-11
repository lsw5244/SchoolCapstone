using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VrGrabAction : MonoBehaviour
{

    public SteamVR_Input_Sources handType;  //모두, 왼손, 오른손
    public SteamVR_Behaviour_Pose controlPose;  //컨트롤러 정보
    public SteamVR_Action_Boolean grabAction; //그랩 액션

    private GameObject collidingObject = null; //충돌중인 객체
    private GameObject objectInHand; //플레이어가 잡은 객체

    void Update()
    {
        //잡는 버튼 누를 때
        if(grabAction.GetLastStateDown(handType))
        {
            if(collidingObject)  //충돌중인 물체 확인
            {
                GrabObject();
            }
        }
        // 잡는 버튼 땔 때
        if(grabAction.GetLastStateUp(handType))
        {
            if(objectInHand)  //잡고있는 물체 확인
            {
                ReleaseObject();
            }
        }
    }
    //충돌 시작
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    //충돌 중
    private void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    //충돌 끝
    private void OnTriggerExit(Collider other)
    {
        if(!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }
    //충돌중인 객체 설정
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }
    //객체를 잡음
    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        FixedJoint joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
    //객체를 놓음
    private void ReleaseObject()
    {
        if(GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = controlPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controlPose.GetAngularVelocity();
        }
        objectInHand = null;
    }
}
