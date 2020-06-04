using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck_enemy : MonoBehaviour
{
    private Enemy enemy;

    void Start()
    {
        enemy = gameObject.GetComponentInParent<Enemy>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("GROUND"))
        {
            enemy.isground = true;
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("GROUND"))
        {
            enemy.isground = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("GROUND"))
        {
            enemy.isground = false;
        }
    }
}
