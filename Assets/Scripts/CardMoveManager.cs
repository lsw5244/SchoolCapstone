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
                    if (deck.Count < maxDeckSize)  //덱 사이즈 확인
                    {

                        deck.Add(hit.collider.gameObject);//덱에 카드추가
                        //카드 움직이기
                        hit.collider.gameObject.GetComponent<inCardMove>().movePos =
                            rightCardPos[deck.IndexOf(hit.collider.gameObject)];
                        hit.collider.gameObject.tag = "DeckCard";//태그 변경
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