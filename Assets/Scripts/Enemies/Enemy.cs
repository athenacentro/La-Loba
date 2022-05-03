using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    EnemyBase _base;
    int level;

    public Enemy(EnemyBase eBase, int eLevel)
    {
        _base = eBase;
        level = eLevel;
    }

    public int Energy
    {
        get { return Mathf.FloorToInt((_base.Energy * level) / 100f) + 5; }
    }
    
    public int Attack
    {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5; }
    }

    public int SpAttack
    {
        get { return Mathf.FloorToInt((_base.SpAttack * level) / 100f) + 5; }
    }

    public int SpDefense
    {
        get { return Mathf.FloorToInt((_base.SpDefense * level) / 100f) + 5; }
    }
}
