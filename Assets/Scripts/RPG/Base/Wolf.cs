using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : EnemyMovement
{
    public Material[] wolfSkin = new Material[4];
    public new Renderer renderer;

    public override void Start()
    {
        base.Start();
        difficulty = Random.Range(1, 5);
        // sets the health of the wolf to the base value multiplied by difficulty and optional multiplier
        attributes[0].maxValue = baseStats[2].value * 5 * difficulty;
        //sets the max health to the current health
        attributes[0].curValue = attributes[0].maxValue;
        //set the base damage of wolf to the Strength times optional multiplier
        baseDamage = baseStats[0].value * 2;
        //changes speed based on dexterity of wolf
        walkSpeed = baseStats[1].value * 2;
        runSpeed = baseStats[1].value * 3;
        
        renderer = GetComponentInChildren<Renderer>();
        //changes wolfskin depending on diffculty
        renderer.material = wolfSkin[difficulty - 1];
    }

    public void BiteAttack()
    {
        int critChance = Random.Range(1, 21);
        float critDamage = 0f;
        if (critChance >= critAmount)
        {
            critDamage = Random.Range(baseDamage / 2, baseDamage * difficulty);
        }

        Debug.Log(baseDamage * difficulty + critDamage);
    }
}
