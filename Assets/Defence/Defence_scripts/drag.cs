using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class drag : CardSeting, IDragHandler
{
    public Transform tr;
    void Start() {
        tr = GetComponent<Transform>();
    }
 
    public void OnDrag(PointerEventData eventData)
    {
        tr.transform.position = Input.mousePosition;
    }

}
