using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceExplosion : Card
{
    public GameObject explosionEffect;
    public float range = 0;
    public string planeTag;
    public string enemyTag;
    public int damage;

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
        if (hitColl == null) //주변에 적 없을 때 탈출
        {
            return;
        }
        int i = 0;
        while (i < hitColl.Length)
        {
            if (hitColl[i].gameObject.tag == enemyTag)
            {
                hitColl[i].gameObject.GetComponent<test_enemy2>().hp -= damage;
            }
            i++;
        }
    }
}
