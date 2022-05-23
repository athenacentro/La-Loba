using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Character/Create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string characterName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] CharPowerType type1;
    [SerializeField] EnemyPowerType type2;
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
        get { return type1; }
    }

    public EnemyPowerType EnemyType
    {
        get { return type2; }
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
