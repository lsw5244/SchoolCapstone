using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUp : Card
{

    public GameObject explosionEffect;
    public float range = 0;
    public string planeTag;
    public string heroTag;
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
        Destroy(Eff, 2f);

        Collider[] hitColl = Physics.OverlapSphere(transform.position, range);
        if (hitColl == null)
        {
            return;
        }
        int i = 0;
        while (i < hitColl.Length)
        {
            if (hitColl[i].gameObject.tag == heroTag)
            {
                if(hitColl[i].gameObject.GetComponent<tower1>() != null)  //근거리 attackspeed 올림
                {
                    hitColl[i].gameObject.GetComponent<tower1>().attackspeed += speed;
                }

                if (hitColl[i].gameObject.GetComponent<tower2>() != null)  //원거리 attackspeed 올림
                {
                    hitColl[i].gameObject.GetComponent<tower2>().attackspeed += speed;
                }                  
            }
            i++;
        }

        

    }
}
