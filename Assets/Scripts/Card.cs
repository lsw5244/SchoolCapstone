using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //카드 번호
    public int number;
    //카드 이름
    public string titile;


    public Card()
    {

    }

    public virtual void Effect()
    {
        Debug.Log("Effcet 미작성시");  //카드에서 Effect 미작성시 호출
    }
   
}
