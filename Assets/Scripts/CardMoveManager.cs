using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveManager : MonoBehaviour
{

    public Transform[] rightCardPos;
    public Transform[] leftCardPos;

    public List<GameObject> deck = new List<GameObject>();

    public int maxDeckSize = 3;

    private void Start()
    {
        deck.Clear();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                if (hit.collider.gameObject.tag == "Card")
                {
                    Debug.Log("CARD!!!!");
                    //hit.collider.gameObject.GetComponent<inCardMove>().movePos = rightCardPos[0];
                    //1. 카드 덱에 넣기
                    //2. 카드 덱을 기준으로rightCardPos로 옮기기
                    if (deck.Count < maxDeckSize)  //덱 찬건지 확인
                    {
                        deck.Add(hit.collider.gameObject);//덱에 카드넣기
                        //카드 움직이기
                        hit.collider.gameObject.GetComponent<inCardMove>().movePos = rightCardPos[deck.IndexOf(hit.collider.gameObject)];
                        //Debug.Log(deck.IndexOf(hit.collider.gameObject));
                        hit.collider.gameObject.tag = "DeckCard";
                    }
                }
                else if (hit.collider.gameObject.tag == "DeckCard")
                {
                    Debug.Log("DeckCardClick!!!!!!!!!!!");
                }
            }

        }
    }



}
