using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Enemy/Create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string enemyName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] PowerType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name
    {
        get { return enemyName; }
    }

    public string Description
    {
        get { return description; }
    }

    public PowerType Type
    {
        get { return type; }
    }

    public int Power
    {
        get { return power; }
    }

    public int Accuracy
    {
        get { return accuracy; }
    }

    public int PP
    {
        get { return pp; }
    }
}
