using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VrActionTest : MonoBehaviour
{

    public SteamVR_Input_Sources handType; //양손, 왼손, 오른손
    public SteamVR_Action_Boolean grabAction;

    void Update()
    {
        if(GetGrab())
        {
            Debug.Log("Grab@@@@@@@@@@@@@@@@@@.");
            //TODO : 그랩 했을 떄 잡은 것 차일드화 하기
            //https://you-rang.tistory.com/261
        }
    }

    public bool GetGrab()
    {
        return grabAction.GetState(handType);
    }
}
