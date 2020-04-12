using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveManager : MonoBehaviour
{

    public Transform[] rightCardPos;
    public Transform[] leftCardPos;

    public GameObject[] deck = new GameObject[3];

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if(hit.collider.gameObject.tag == "Card")
                {
                    Debug.Log("CARD!!!!");
                    //hit.collider.gameObject.GetComponent<inCardMove>().movePos = rightCardPos[0];
                    //1. 카드 덱에 넣기
                    //2. 카드 덱을 기준으로rightCardPos로 옮기기
                    if(deck[deck.Length - 1] == null)  //덱 찬건지 확인
                    {                 
                        for (int i = 0; i < deck.Length; i++)
                        {
                            if (deck[i] == null)
                            {
                                deck[i] = hit.collider.gameObject;
                                hit.collider.gameObject.GetComponent<inCardMove>().movePos = rightCardPos[i];
                                break;
                            }
                        }
                        
                    }

                }
            }
        }



    }

  
}
