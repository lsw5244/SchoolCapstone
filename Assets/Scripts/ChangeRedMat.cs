using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRedMat : MonoBehaviour
{
    Card card = new Card();

    void Start()
    {
        card.number = 1;
        card.titile = "ChangeRedMat";

        //card.Effect();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Effect();
            Debug.Log(card.number);
            Debug.Log(card.titile);
        }
    }

    public void Effect()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enermy");
        foreach(GameObject obj in objs)
        {
            obj.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }


}
