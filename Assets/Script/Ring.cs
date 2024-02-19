using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;
    public GameObject[] childRing;

    float radius = 100f;
    float force = 500f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(transform.position.y > player.position.y)
        {
            GameManager.noOfPassingRings++;
            for(int i = 0; i < childRing.Length; i++)
            {
                childRing[i].GetComponent<Rigidbody> ().isKinematic = false;
                childRing[i].GetComponent<Rigidbody> ().useGravity = true;

                Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

                foreach(Collider collider in colliders)
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(force, transform.position, radius);
                    }
                }
                childRing[i].GetComponent<MeshCollider>().enabled = false;
                childRing[i].transform.parent = null;
                Destroy(childRing[i].gameObject, 2f);
                Destroy(this.gameObject, 5f);
            }
            this.enabled = false;
        }
    }
}
