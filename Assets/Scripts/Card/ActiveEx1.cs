using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveEx1 : Card
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                GameObject Eff = Instantiate(particleEffect, hit.point, Quaternion.identity);
                Destroy(Eff, 1.5f);

                Collider[] hitColl = Physics.OverlapSphere(hit.point, range);

                StartCoroutine("SpreadEffect", hitColl);

            }
        }
    }

    IEnumerator SpreadEffect(Collider[] colls)
    {
        foreach(Collider coll in colls)
        {
            if(coll.tag == "Enermy")
            {
                coll.GetComponent<MeshRenderer>().material.color = Color.green;
                yield return new WaitForSeconds(0.3f);
            }

        }
    }
}
