using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newone : MonoBehaviour
{
    public GameObject one;
    public Vector3 tr;
 

    private void Start()
    {
        tr = this.transform.position;
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GROUND")
        {
            Instantiate(one, transform.position, Quaternion.identity);
            transform.position = tr;
        }
    }
}
