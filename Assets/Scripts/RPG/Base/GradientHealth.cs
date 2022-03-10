using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradientHealth : Stats
{
    public Gradient gradient;
    public Canvas enemyHealthDisplay;
    Transform cam;
    public override void Start()
    {
        cam = Camera.main.transform;
    }

    public virtual void Update()
    {
        SetHealth();
        //makes health display always face main camera
        enemyHealthDisplay.transform.LookAt(enemyHealthDisplay.transform.position + cam.forward);
    }

    public void SetHealth()
    {
        // creates a % of health left between current and max to show remaining health
        attributes[0].display.fillAmount = Mathf.Clamp01(attributes[0].curValue / attributes[0].maxValue);
        //taking the amount on our health bar change the colour according to gradient
        attributes[0].display.color = gradient.Evaluate(attributes[0].display.fillAmount);
    }
}
