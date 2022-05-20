using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] CharacterBase _base;
    [SerializeField] EnemyBase _eBase;

    [SerializeField] int level;
    [SerializeField] bool rightSide;

    public Character Character { get; set; }
    public Enemy Enemy { get; set; }

    public void SetupCharacter()
    {
        Character = new Character(_base, level);

        if (rightSide)
            GetComponent<Image>().sprite = Character.Base.LeftFacingSprite;
        else
            GetComponent<Image>().sprite = Character.Base.RightFacingSprite;
    }

    public void SetupEnemy()
    {
        Enemy = new Enemy(_eBase, level);

        if (rightSide)
            GetComponent<Image>().sprite = Enemy.Base.LeftFacingSprite;
        else
            GetComponent<Image>().sprite = Enemy.Base.RightFacingSprite;
    }
}
