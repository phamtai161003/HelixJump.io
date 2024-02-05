using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    public float bounceForce = 400f;
    //public GameObject spilitPrefab;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.velocity = new Vector3(rb.velocity.x, bounceForce * Time.deltaTime, rb.velocity.z);
       // GameObject newsplit = Instantiate(spilitPrefab, new Vector3(transform.position.x, other.transform.position.y, transform.position.z), transform.rotation);
    }
}
