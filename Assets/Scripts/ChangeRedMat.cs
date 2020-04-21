using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRedMat : Card
{
    void Start()
    {
        number = 1;
        titile = "ChangeRedMat";
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))  //사용 트리거
        {
            Effect();
            Debug.Log(number);
            Debug.Log(titile);
        }
    }

    public override void Effect()  //임시 Effect
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enermy");
        foreach(GameObject obj in objs)
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}