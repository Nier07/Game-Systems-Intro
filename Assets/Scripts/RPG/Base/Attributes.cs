using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Attributes : MonoBehaviour
{
    [System.Serializable]
    public struct Attribute
    {
        public string name;
        public float curValue;
        public float maxValue;
        public float tempValue;
        public float regenValue;
        public Image display;
    }
    public Attribute[] attributes = new Attribute[3];

    //virtual means the function can be over-ridden/changed in the future
    public virtual void Start()
    {
        attributes[0].name = "Health";
        attributes[1].name = "Mana";
        attributes[2].name = "Stamina";
    }
}
