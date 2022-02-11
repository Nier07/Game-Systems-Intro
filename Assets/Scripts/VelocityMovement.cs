using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Interacts with phys objects
        //doesent register ground by default (have to write is ground check)
        //does register gravity by defult
        //directley changes speed by set velocity (no acceleration)
        //can spin and bounce and shit
        rb.velocity = Vector3.forward * speed;
    }
}
