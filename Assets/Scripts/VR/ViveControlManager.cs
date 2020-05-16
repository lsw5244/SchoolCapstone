using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class ViveControlManager : MonoBehaviour
{

    public SteamVR_Action_Boolean TriggerBoolean;

    void Start()
    {
        
    }

    void Update()
    {
        if(TriggerBoolean.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("@@@@@@@@@@@@@@");
        }
    }
}
