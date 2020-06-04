using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSpeedDown : Card
{
    public GameObject explosionEffect;
    public float range = 0;
    public string planeTag;
    public string enemyTag;
    public int speed;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == planeTag)
        {
            Effect();
            Destroy(this.gameObject);
        }
    }

    public override void Effect()
    {
        GameObject Eff = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(Eff, 1.5f);

        Collider[] hitColl = Physics.OverlapSphere(transform.position, range);
        if (hitColl == null)
        {
            return;
        }
        int i = 0;
        while (i < hitColl.Length)
        {
            if (hitColl[i].gameObject.tag == enemyTag)
            {
                hitColl[i].gameObject.GetComponent<test_enemy2>().attackspeed -= speed;

            }
            i++;
        }



    }
}
