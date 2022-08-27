using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuffs : MonoBehaviour
{

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

    public void ActivateBuffs(Buffs buff)
    {

        ProjectileGun tempGun = GunContainer.GetComponentInChildren<ProjectileGun>();
        CustomBullet tempBullet = tempGun.bulletScript;


        //Ativar os efeitos do buff.
        for (int i = 0; i < buff.buffsTypes.Count; i++)
        {

            switch (buff.buffsTypes[i])
            {

                case ModifierType.AttackSpeed:

                    switch (buff.buffsModifiers[i])
                    {

                        case Operator.Addition:

                            tempGun.timeBetweenShooting += buff.modifiers[i];

                            break;
                        case Operator.Subtraction:

                            tempGun.timeBetweenShooting -= buff.modifiers[i];

                            break;
                        case Operator.Multiply:

                            tempGun.timeBetweenShooting *= buff.modifiers[i];

                            break;
                        case Operator.Division:

                            tempGun.timeBetweenShooting /= buff.modifiers[i];

                            break;


                    }

                    break;
                case ModifierType.Damage:


                    switch (buff.buffsModifiers[i])
                    {

                        case Operator.Addition:

                            tempBullet.explosionDamage += (int) buff.modifiers[i];

                            break;
                        case Operator.Subtraction:

                            tempBullet.explosionDamage -= (int)buff.modifiers[i];

                            break;
                        case Operator.Multiply:

                            tempBullet.explosionDamage *= (int)buff.modifiers[i];

                            break;
                        case Operator.Division:

                            tempBullet.explosionDamage /= (int)buff.modifiers[i];

                            break;


                    }

                    break;
                case ModifierType.Defense:

                    switch (buff.buffsModifiers[i])
                    {

                        case Operator.Addition:

                            playerScript.playerDefense += buff.modifiers[i];

                            break;
                        case Operator.Subtraction:

                            playerScript.playerDefense -= buff.modifiers[i];

                            break;
                        case Operator.Multiply:

                            playerScript.playerDefense *= buff.modifiers[i];

                            break;
                        case Operator.Division:

                            playerScript.playerDefense /= buff.modifiers[i];

                            break;


                    }

                    break;
            }

        }

        for (int j = 0; j < BuffsSlotsContent.Count; j++)
        {
            if (BuffsSlotsContent[j] == Element.None)
            {
                BuffsSlotsContent[j] = buff.element;
                ActiveBuffsSlots[j].GetComponent<Image>().sprite = buff.elementSprite;

            }
            

        }

    }


    public void DeActivateBuffs(Buffs buff)
    {

        ProjectileGun tempGun = GunContainer.GetComponentInChildren<ProjectileGun>();
        CustomBullet tempBullet = tempGun.bulletScript;

        //Desativar os efeitos do buff.
        for (int i = 0; i < buff.buffsTypes.Count; i++)
        {

            switch (buff.buffsTypes[i])
            {

                case ModifierType.AttackSpeed:

                    switch (buff.buffsModifiers[i])
                    {

                        case Operator.Addition:

                            tempGun.timeBetweenShooting -= buff.modifiers[i];

                            break;
                        case Operator.Subtraction:

                            tempGun.timeBetweenShooting += buff.modifiers[i];

                            break;
                        case Operator.Multiply:

                            tempGun.timeBetweenShooting /= buff.modifiers[i];

                            break;
                        case Operator.Division:

                            tempGun.timeBetweenShooting *= buff.modifiers[i];

                            break;


                    }

                    break;
                case ModifierType.Damage:


                    switch (buff.buffsModifiers[i])
                    {

                        case Operator.Addition:

                            tempBullet.explosionDamage -= (int)buff.modifiers[i];

                            break;
                        case Operator.Subtraction:

                            tempBullet.explosionDamage += (int)buff.modifiers[i];

                            break;
                        case Operator.Multiply:

                            tempBullet.explosionDamage /= (int)buff.modifiers[i];

                            break;
                        case Operator.Division:

                            tempBullet.explosionDamage *= (int)buff.modifiers[i];

                            break;


                    }

                    break;
                case ModifierType.Defense:

                    switch (buff.buffsModifiers[i])
                    {

                        case Operator.Addition:

                            playerScript.playerDefense -= buff.modifiers[i];

                            break;
                        case Operator.Subtraction:

                            playerScript.playerDefense += buff.modifiers[i];

                            break;
                        case Operator.Multiply:

                            playerScript.playerDefense /= buff.modifiers[i];

                            break;
                        case Operator.Division:

                            playerScript.playerDefense *= buff.modifiers[i];

                            break;


                    }

                    break;
            }

        }

        for (int j = 0; j < BuffsSlotsContent.Count; j++)
        {
            if (BuffsSlotsContent[j] == buff.element)
            {
                BuffsSlotsContent[j] = Element.None;
                ActiveBuffsSlots[j].GetComponent<Image>().sprite = null;

            }


        }

    }


}
