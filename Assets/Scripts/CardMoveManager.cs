using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveManager : MonoBehaviour
{

    public Transform[] rightCardPos;
    public Transform[] leftCardPos;

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
                    hit.collider.gameObject.GetComponent<inCardMove>().movePos = rightCardPos[0];
                    
                }
            }
        }



    }

  
}
