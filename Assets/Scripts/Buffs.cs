using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "ScriptableObjects/Buff")]
public class Buffs : ScriptableObject
{

    public Element element;

    public Sprite elementSprite;

    public List<ModifierType> buffsTypes;

    public List<Operator> buffsModifiers;

    public List<float> modifiers;

}

public enum ModifierType { AttackSpeed , Damage , Defense, Bouncing }
public enum Operator { Addition , Subtraction , Multiply , Division }
public enum Element { None, Fire, Water, Shock, Earth }

