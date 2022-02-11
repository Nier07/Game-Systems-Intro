using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        //teleports forward evey update frame
        //ignores physics objects
        //adjusts position/speed based on delta time (time between frames)
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
