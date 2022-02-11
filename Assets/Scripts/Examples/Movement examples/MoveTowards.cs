using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public float speed = 5f;
    // Update is called once per frame
    void Update()
    {
        //moves towards a specific point in space
        //teleports forward evey update frame
        //ignores physics objects
        //adjusts position/speed based on delta time (time between frames)
        transform.position = Vector3.MoveTowards(transform.position, new Vector3 (0, 0, 50), speed * Time.deltaTime);
    }
}
