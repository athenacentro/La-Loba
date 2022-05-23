using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public EnemyBase Base { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public Character Character { get; set; }

    public List<Move> Moves { get; set; }

    public Enemy(EnemyBase eBase, int eLevel)
    {
        Base = eBase;
        Level = eLevel;
        HP = MaxHp;

        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves)
        {
            if (move.Level <= Level)
                Moves.Add(new Move(move.Base));

            if (Moves.Count >= 4)
                break;
        }
    }

    public int Energy
    {
        get { return Mathf.FloorToInt((Base.Energy * Level) / 100f) + 5; }
    }
    
    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5; }
    }

    public int SpAttack
    {
        get { return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) + 5; }
    }

    public int SpDefense
    {
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5; }
    }

    public int MaxHp
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 10; }
    }

    public EnemDamageDetails TakeDamage(Move move, Character attacker)
    {
        float critical = 1f;
        if (Random.value * 100f <= 6.25f)
        {
            critical = 2f;
        }

        float type = EnemTypeChart.GetEffectiveness(move.Base.EnemyType, this.Base.Type1) * EnemTypeChart.GetEffectiveness(move.Base.EnemyType, this.Base.Type2);

        var enemDamageDetails = new EnemDamageDetails()
        {
            TypeEffectiveness = type,
            Critical = critical,
            Fainted = false
        };

        float modifiers = Random.Range(0.85f, 1f) * type * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            enemDamageDetails.Fainted = true;
        }

        return enemDamageDetails;
    }

    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }

    public class EnemDamageDetails
    {
        public bool Fainted { get; set; }

        public float Critical { get; set; }

        public float TypeEffectiveness { get; set; }


    }
}
