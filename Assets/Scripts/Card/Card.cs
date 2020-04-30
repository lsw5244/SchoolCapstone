using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //카드 번호
    [HideInInspector] public int number;
    //카드 이름
    [HideInInspector] public string title;
    //카드 0, 1, 2
    [HideInInspector] public int status;
    //cost
    [HideInInspector] public int cost;

    public Card()
    {

    }

    public virtual void Effect()
    {
        Debug.Log("Effcet 미작성");  //카드에서 Effect 미작성시 호출
    }
}
