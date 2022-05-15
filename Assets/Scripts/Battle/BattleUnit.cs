using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] EnemyBase _base;
    [SerializeField] int level;
    [SerializeField] bool rightSide;

    public Enemy Enemy { get; set; }

    public void Setup()
    {
        Enemy = new Enemy(_base, level);

        if (rightSide)
            GetComponent<Image>().sprite = Enemy.Base.LeftSprite;
        else
            GetComponent<Image>().sprite = Enemy.Base.RightSprite;
    }
}
