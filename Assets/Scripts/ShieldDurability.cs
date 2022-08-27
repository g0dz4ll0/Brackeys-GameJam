using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDurability : MonoBehaviour
{

    public Skills skillsScript;

    public float defaultDurability;
    public float durability;

    public float currentDurability;

    private void OnEnable()
    {
        currentDurability = defaultDurability;
    }

    private void Start()
    {

        currentDurability = durability;

    }
    
    public void TakeDmg(float dmg)
    {

        currentDurability -= dmg;

        if(currentDurability <= 0)
        {
            skillsScript.DeActivateWater();
        }

    }

}
