using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 scr;
    private float pixelsPerUnit;
    // Start is called before the first frame update
    void Start()
    {
        scr.x = Screen.width / 16;
        scr.y = Screen.height / 9;
    }

    // Update is called once per frame
    void Update()
    {
        if (Screen.width/16 != scr.x)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        } 
    }
}
