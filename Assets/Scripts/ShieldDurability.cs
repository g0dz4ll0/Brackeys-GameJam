using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDurability : MonoBehaviour
{
    public Slider shieldSlider;
    public Skills skillsScript;

    public float defaultDurability;
    public float durability;

    public float currentDurability;

    private void OnEnable()
    {
        currentDurability = defaultDurability;
        shieldSlider.value = currentDurability;
    }

    private void Start()
    {
        currentDurability = durability;
        shieldSlider.maxValue = currentDurability;
    }
    
    public void TakeDmg(float dmg)
    {
        currentDurability -= dmg;
        shieldSlider.value = currentDurability;

        if(currentDurability <= 0)
        {
            skillsScript.DeActivateWater();
        }
    }

}
