using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuffs : MonoBehaviour
{


    [Header("Buffs")]

    public Buffs fireBuff;
    public Buffs waterBuff;
    public Buffs shockBuff;
    public Buffs earthBuff;

    [Header("Referencias")]
    public GameObject GunContainer;
    public Player playerScript;
    public List<GameObject> ActiveBuffsSlots;


    List<Element> BuffsSlotsContent;



    private void Start()
    {
        BuffsSlotsContent = new List<Element>();

        for(int i= 0; i < ActiveBuffsSlots.Count; i++)
        {
            BuffsSlotsContent.Add(Element.None);
        }
    }

    public void ActivateBuffs(string element)
    {

        Buffs buffToAdd = null;

        switch (element)
        {

            case "Fire":
                buffToAdd = fireBuff;
                break;
            case "Water":
                buffToAdd = waterBuff;
                break;
            case "Shock":
                buffToAdd = shockBuff;
                break;
            case "Earth":
                buffToAdd = earthBuff;
                break;

        }            


        ProjectileGun tempGun = GunContainer.GetComponentInChildren<ProjectileGun>();

        if(tempGun != null)
        {

            CustomBullet tempBullet = tempGun.bulletScript;


            //Ativar os efeitos do buff.
            for (int i = 0; i < buffToAdd.buffsTypes.Count; i++)
            {

                switch (buffToAdd.buffsTypes[i])
                {

                    case ModifierType.AttackSpeed:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                tempGun.timeBetweenShooting += buffToAdd.modifiers[i];

                                break;
                            case Operator.Subtraction:

                                tempGun.timeBetweenShooting -= buffToAdd.modifiers[i];

                                break;
                            case Operator.Multiply:

                                tempGun.timeBetweenShooting *= buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                tempGun.timeBetweenShooting /= buffToAdd.modifiers[i];

                                break;


                        }

                        break;
                    case ModifierType.Damage:


                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                tempBullet.explosionDamage += (int) buffToAdd.modifiers[i];

                                break;
                            case Operator.Subtraction:

                                tempBullet.explosionDamage -= (int)buffToAdd.modifiers[i];

                                break;
                            case Operator.Multiply:

                                tempBullet.explosionDamage *= (int)buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                tempBullet.explosionDamage /= (int)buffToAdd.modifiers[i];

                                break;


                        }

                        break;
                    case ModifierType.Defense:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                playerScript.playerDefense += buffToAdd.modifiers[i];

                                break;
                            case Operator.Subtraction:

                                playerScript.playerDefense -= buffToAdd.modifiers[i];

                                break;
                            case Operator.Multiply:

                                playerScript.playerDefense *= buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                playerScript.playerDefense /= buffToAdd.modifiers[i];

                                break;


                        }

                        break;
                    case ModifierType.Bouncing:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                               tempBullet.maxCollisions += (int) buffToAdd.modifiers[i];
                               tempBullet.explodeOnTouch = false;

                                break;
                            case Operator.Subtraction:

                                tempBullet.maxCollisions -= (int)buffToAdd.modifiers[i];
                                tempBullet.explodeOnTouch = false;

                                break;
                            case Operator.Multiply:

                                tempBullet.maxCollisions *= (int)buffToAdd.modifiers[i];
                                tempBullet.explodeOnTouch = false;

                                break;
                            case Operator.Division:

                                tempBullet.maxCollisions /= (int)buffToAdd.modifiers[i];
                                tempBullet.explodeOnTouch = false;

                                break;

                        }
                        break;
                    case ModifierType.Scale:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                               tempBullet.transform.localScale += new Vector3 ((int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i]);

                                break;
                            case Operator.Subtraction:

                                tempBullet.transform.localScale -= new Vector3 ((int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i]);

                                break;
                            case Operator.Multiply:

                                tempBullet.transform.localScale *= (int)buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                tempBullet.transform.localScale /= (int)buffToAdd.modifiers[i];

                                break;

                        }
                        break;
                    case ModifierType.Gravity:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                               tempBullet.useGravity = true;
                               tempGun.shootForce = 15f; 

                                break;
                            case Operator.Subtraction:

                                tempBullet.useGravity = true;
                                tempGun.shootForce = 15f; 

                                break;
                            case Operator.Multiply:

                                tempBullet.useGravity = true;
                                tempGun.shootForce = 15f; 

                                break;
                            case Operator.Division:

                                tempBullet.useGravity = true;
                                tempGun.shootForce = 15f; 

                                break;

                        }
                        break;
                    case ModifierType.Bounciness:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                if (tempBullet.bounciness + buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness + buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness += buffToAdd.modifiers[i];
                                }

                                break;
                            case Operator.Subtraction:

                                if (tempBullet.bounciness - buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness - buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness -= buffToAdd.modifiers[i];
                                } 

                                break;
                            case Operator.Multiply:

                                if (tempBullet.bounciness * buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness * buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness *= buffToAdd.modifiers[i];
                                } 

                                break;
                            case Operator.Division:

                                if (tempBullet.bounciness / buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness / buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness /= buffToAdd.modifiers[i];
                                } 

                                break;
                        }
                        break;
                    case ModifierType.ShootUp:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                tempGun.upwardForce = 8f;

                                break;
                            case Operator.Subtraction:

                                tempGun.upwardForce = 8f;

                                break;
                            case Operator.Multiply:

                                tempGun.upwardForce = 8f;

                                break;
                            case Operator.Division:

                                tempGun.upwardForce = 8f;

                                break;

                        }
                        break;
                }

            }

        }

        Debug.Log("Ola");

        bool hasBuffed = false;

        for (int j = 0; j < BuffsSlotsContent.Count; j++)
        {
            if (BuffsSlotsContent[j] == Element.None && !hasBuffed)
            {
                BuffsSlotsContent[j] = buffToAdd.element;
                ActiveBuffsSlots[j].GetComponent<Image>().sprite = buffToAdd.elementSprite;

                Color tempColor = ActiveBuffsSlots[j].GetComponent<Image>().color;

                tempColor.a = 1f;

                ActiveBuffsSlots[j].GetComponent<Image>().color = tempColor;

                Debug.Log("Slot : " + j);

                hasBuffed = true;
            }

            

        }

    }


    public void DeActivateBuffs(string element)
    {

        Buffs buffToAdd = null;

        switch (element)
        {

            case "Fire":
                buffToAdd = fireBuff;
                break;
            case "Water":
                buffToAdd = waterBuff;
                break;
            case "Shock":
                buffToAdd = shockBuff;
                break;
            case "Earth":
                buffToAdd = earthBuff;
                break;

        }

        ProjectileGun tempGun = GunContainer.GetComponentInChildren<ProjectileGun>();

        if(tempGun != null)
        {


            CustomBullet tempBullet = tempGun.bulletScript;

            //Desativar os efeitos do buff.
            for (int i = 0; i < buffToAdd.buffsTypes.Count; i++)
            {

                switch (buffToAdd.buffsTypes[i])
                {

                    case ModifierType.AttackSpeed:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                tempGun.timeBetweenShooting -= buffToAdd.modifiers[i];

                                break;
                            case Operator.Subtraction:

                                tempGun.timeBetweenShooting += buffToAdd.modifiers[i];

                                break;
                            case Operator.Multiply:

                                tempGun.timeBetweenShooting /= buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                tempGun.timeBetweenShooting *= buffToAdd.modifiers[i];

                                break;


                        }

                        break;
                    case ModifierType.Damage:


                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                tempBullet.explosionDamage -= (int)buffToAdd.modifiers[i];

                                break;
                            case Operator.Subtraction:

                                tempBullet.explosionDamage += (int)buffToAdd.modifiers[i];

                                break;
                            case Operator.Multiply:

                                tempBullet.explosionDamage /= (int)buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                tempBullet.explosionDamage *= (int)buffToAdd.modifiers[i];

                                break;


                        }

                        break;
                    case ModifierType.Defense:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                playerScript.playerDefense -= buffToAdd.modifiers[i];

                                break;
                            case Operator.Subtraction:

                                playerScript.playerDefense += buffToAdd.modifiers[i];

                                break;
                            case Operator.Multiply:

                                playerScript.playerDefense /= buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                playerScript.playerDefense *= buffToAdd.modifiers[i];

                                break;


                        }

                        break;
                    case ModifierType.Bouncing:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                tempBullet.maxCollisions -= (int)buffToAdd.modifiers[i];
                                tempBullet.explodeOnTouch = true;

                                break;
                            case Operator.Subtraction:

                                tempBullet.maxCollisions += (int)buffToAdd.modifiers[i];
                                tempBullet.explodeOnTouch = true;

                                break;
                            case Operator.Multiply:

                                tempBullet.maxCollisions /= (int)buffToAdd.modifiers[i];
                                tempBullet.explodeOnTouch = true;

                                break;
                            case Operator.Division:

                                tempBullet.maxCollisions *= (int)buffToAdd.modifiers[i];
                                tempBullet.explodeOnTouch = true;

                                break;

                        }
                        break;
                    case ModifierType.Scale:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                               tempBullet.transform.localScale -= new Vector3 ((int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i]);

                                break;
                            case Operator.Subtraction:

                                tempBullet.transform.localScale += new Vector3 ((int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i], (int)buffToAdd.modifiers[i]);

                                break;
                            case Operator.Multiply:

                                tempBullet.transform.localScale /= (int)buffToAdd.modifiers[i];

                                break;
                            case Operator.Division:

                                tempBullet.transform.localScale *= (int)buffToAdd.modifiers[i];

                                break;

                        }
                        break;
                    case ModifierType.Gravity:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                               tempBullet.useGravity = true;
                               tempGun.shootForce = tempGun.defaultShootForce;

                                break;
                            case Operator.Subtraction:

                                tempBullet.useGravity = true;
                                tempGun.shootForce = tempGun.defaultShootForce; 

                                break;
                            case Operator.Multiply:

                                tempBullet.useGravity = true;
                                tempGun.shootForce = tempGun.defaultShootForce; 

                                break;
                            case Operator.Division:

                                tempBullet.useGravity = true;
                                tempGun.shootForce = tempGun.defaultShootForce; 

                                break;

                        }
                        break;
                    case ModifierType.Bounciness:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                if (tempBullet.bounciness - buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness - buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness -= buffToAdd.modifiers[i];
                                }

                                break;
                            case Operator.Subtraction:

                                if (tempBullet.bounciness + buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness + buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness += buffToAdd.modifiers[i];
                                } 

                                break;
                            case Operator.Multiply:

                                if (tempBullet.bounciness / buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness / buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness /= buffToAdd.modifiers[i];
                                } 

                                break;
                            case Operator.Division:

                                if (tempBullet.bounciness * buffToAdd.modifiers[i] >= 0f && tempBullet.bounciness * buffToAdd.modifiers[i] <= 1f)
                                {
                                    tempBullet.bounciness *= buffToAdd.modifiers[i];
                                } 

                                break;

                        }
                        break;
                    case ModifierType.ShootUp:

                        switch (buffToAdd.buffsModifiers[i])
                        {

                            case Operator.Addition:

                                tempGun.upwardForce = tempGun.defaultUpwardForce;

                                break;
                            case Operator.Subtraction:

                                tempGun.upwardForce = tempGun.defaultUpwardForce;

                                break;
                            case Operator.Multiply:

                                tempGun.upwardForce = tempGun.defaultUpwardForce;

                                break;
                            case Operator.Division:

                                tempGun.upwardForce = tempGun.defaultUpwardForce;

                                break;

                        }
                        break;
                }

            }

        }

        for (int j = 0; j < BuffsSlotsContent.Count; j++)
        {
            if (BuffsSlotsContent[j] == buffToAdd.element)
            {
                BuffsSlotsContent[j] = Element.None;
                ActiveBuffsSlots[j].GetComponent<Image>().sprite = null;

                Color tempColor = ActiveBuffsSlots[j].GetComponent<Image>().color;

                tempColor.a = 0f;

                ActiveBuffsSlots[j].GetComponent<Image>().color = tempColor;

                return;
            }


        }

    }


}
