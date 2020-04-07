using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inCardMove : MonoBehaviour
{
    public Transform movePos;

    void Update()
    {
        if(!(movePos == null))
            transform.position = Vector3.Lerp(transform.position, movePos.position, 0.01f);
    }

}
