using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int damage;
    public Vector3 direction;
    void Start()
    {
        Destroy(gameObject, 0.02f);
        direction = direction.normalized;//방향값을 정규화한다.
        float angle = Mathf.Atan2(-direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "ENEMY")
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
