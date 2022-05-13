using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create New Enemy")]
public class EnemyBase : ScriptableObject
{
    [SerializeField] string enemyName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] EnemyType type1;

    [SerializeField] int energy;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description;  }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public EnemyType Type1
    {
        get { return type1; }
    }

    public int Energy
    {
        get { return energy; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public int SpAttack 
    {
        get { return spAttack; }
    }

    public int SpDefense
    {
        get { return spDefense; }
    }
}

public enum EnemyType
{
    None,
    Raccoons,
    Rattlesnakes,
    Crows,
    Wolves
}