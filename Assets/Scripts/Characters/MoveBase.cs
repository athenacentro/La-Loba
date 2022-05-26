using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Character/Create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string characterName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] CharPowerType charPower;
    [SerializeField] EnemyPowerType enemPower;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name
    {
        get { return characterName; }
    }

    public string Description
    {
        get { return description; }
    }

    public CharPowerType CharType
    {
        get { return charPower; }
    }

    public EnemyPowerType EnemyType
    {
        get { return enemPower; }
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
