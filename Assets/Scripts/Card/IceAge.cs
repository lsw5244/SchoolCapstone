using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAge : Card
{
    public GameObject particleEffect;
    public float range;

    void Start()
    {
        number = 2;
        title = "IceAge";
        status = 0;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                GameObject Eff = Instantiate(particleEffect, hit.point, Quaternion.identity);
                Destroy(Eff, 1.5f);

                Collider[] hitColl = Physics.OverlapSphere(hit.point, range);

                int i = 0;
                while(i < hitColl.Length)
                {
                    if(hitColl[i].gameObject.tag == "Enermy")
                        hitColl[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

                    i++;
                }
            }         
        }
    }
}
