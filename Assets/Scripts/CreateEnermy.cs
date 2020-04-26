using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnermy : MonoBehaviour
{
    float x;
    float z;

    public int enermyCount;
    public GameObject enermy;
    void Start()
    {
        

        for(int i = 0; i < enermyCount; i++)
        {
            x = Random.Range(-9, 9);
            z = Random.Range(-9, 9);
            Instantiate(enermy, new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}
