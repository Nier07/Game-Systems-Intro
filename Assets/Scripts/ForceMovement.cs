using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Interacts with phys objects
        //doesent register ground by default (have to write is ground check)
        //does register gravity by defult
        //accelerates the object
        //can spin and bounce and shit
        //good for ice-like objects or driving games
        rb.AddForce(Vector3.forward * speed);
    }
}
