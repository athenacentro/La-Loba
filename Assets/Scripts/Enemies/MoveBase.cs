using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Enemy/Create New Move")]
public class MoveBase : ScriptableObject
{
    [SerializeField] string enemyName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] EnemyType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;


}
