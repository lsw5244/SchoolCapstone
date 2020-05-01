using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //number(int)
    [HideInInspector] public int number;
    //title(string)
    [HideInInspector] public string title;
    //1, 2(int)
    [HideInInspector] public int status;
    //cost (int)
    [HideInInspector] public int cost;
    // Active / Passive (string)
    [HideInInspector] public string type;

    public Card()
    {

    }

    public virtual void Effect()
    {
        Debug.Log("Effcet 미작성");  //카드에서 Effect 미작성시 호출
    }
}
