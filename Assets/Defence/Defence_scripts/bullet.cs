using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class bullet : MonoBehaviour
    {
        public int damage;
        public float speed;
        void Start()
        {
          GetComponent<Rigidbody>().AddForce(transform.forward*speed);          
        }
        public void OnTriggerEnter(Collider col)
        {
            if (col.tag == "ENEMY")
            {
                Destroy(gameObject,0.01f);
            }
        }

    }
