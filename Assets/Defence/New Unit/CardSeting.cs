using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class CardSeting : MonoBehaviour
{
    public Vector3 cardpos;
    public GameObject card;
    //타워를 놓을 위치
    public Transform tr;
    public GameObject tower;
    Rigidbody rb;
    //어디에 놓을지 가르키는 선의 길이
    //public float MaxDistance = 15.0f;

    private void Update()
    {
        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        //if (cardpos != transform.position)
        //{
          //  Instantiate(card, cardpos, Quaternion.identity);
        //}
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "GROUND")
        {
            Instantiate(tower, card.transform.position, Quaternion.identity);
            //tr.position = new Vector3(cardpos.x, cardpos.y, cardpos.z);
        }
        else
        {
            //tr.position = new Vector3(cardpos.x, cardpos.y, cardpos.z);
        }
     }

    
}
