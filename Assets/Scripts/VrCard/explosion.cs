using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : Card
{

    public GameObject particleEffect;
    public float range;


    private void OnCollisionEnter(Collision coll)  //plane에 닿음
    {
        if(coll.gameObject.tag == "Plane")
        {
            Debug.Log("Coll!!!!!!!!!!!!!");
            Effect();//카드 Effect실행
            Destroy(this.gameObject);//카드 오브젝트 파괴  //TODO : 묘지로 가게 될 때 적기
        }
    }

    public override void Effect()
    {
        GameObject Eff = Instantiate(particleEffect, transform.position, Quaternion.identity);
        Destroy(Eff, 1.5f);

        Collider[] hitColl = Physics.OverlapSphere(transform.position, range);

        int i = 0;
        while (i < hitColl.Length)
        {
            if (hitColl[i].gameObject.tag == "Enermy")
            {
                hitColl[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                Destroy(hitColl[i].gameObject, 1.5f);
            }
            i++;
        }
    }
}
