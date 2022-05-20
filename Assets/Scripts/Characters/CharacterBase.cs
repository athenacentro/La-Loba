using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Character", menuName = "Character/Create New Character")]
public class CharacterBase : ScriptableObject
{
    [SerializeField] string characterName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite leftFacingSprite;
    [SerializeField] Sprite rightFacingSprite;

    [SerializeField] CharPowerType type1;

    [SerializeField] int energy;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;

    [SerializeField] List<LearnableMove> learnablesMoves;

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite LeftFacingSprite
    {
        get { return leftFacingSprite; }
    }

    public Sprite RightFacingSprite
    {
        get { return rightFacingSprite; }
    }

    public CharPowerType Type1
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

    public List<LearnableMove> LearnableMoves
    {
        get { return learnablesMoves; }
    }
}

[System.Serializable]

public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}

public enum CharPowerType
{
    None,
    Normal,
    Special
}
