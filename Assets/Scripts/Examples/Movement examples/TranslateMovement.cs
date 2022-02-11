using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        //teleports forward evey update frame
        //ignores physics objects
        //adjusts position/speed based on delta time (time between frames)
        //move forward by speed times time between each frame to normalize time
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }
}
