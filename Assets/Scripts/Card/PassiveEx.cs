using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEx : Card
{
    public GameObject particleEffect;

    void Start()
    {
        number = 1;
        type = "Passive";
        title = "Buff";

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Effect();
        }
    }

    public override void Effect()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Enermy");

        foreach(GameObject unit in units)
        {
            GameObject particle = Instantiate(particleEffect, unit.transform.position, Quaternion.identity);
            Destroy(particle, 3f);
        }

    }
}
