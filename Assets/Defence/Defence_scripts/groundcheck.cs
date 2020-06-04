using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour{
   private Unit unit;

    void Start() {
        unit = gameObject.GetComponentInParent<Unit>();   
    }
void OnTriggerEnter(Collider col) {
        if (col.CompareTag("GROUND"))    {
            unit.isground = true;
        }     }
 void OnTriggerStay(Collider col)   {
        if (col.CompareTag("GROUND"))  {
            unit.isground = true;
        }
    }
  void OnTriggerExit(Collider col) {
        if (col.CompareTag("GROUND"))    {
            unit.isground = false;
        }
    }
}
