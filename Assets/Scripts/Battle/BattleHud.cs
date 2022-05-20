using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text lvlText;
    [SerializeField] HPBar hpBar;

    Character _character;
    Enemy _enemy;

    public void SetDataChar(Character character)
    {
        _character = character;

        nameText.text = character.Base.Name;
        lvlText.text = "Lvl" + character.Level;
        hpBar.SetHP((float) character.HP / character.MaxHp);
    }

    public void SetDataEnem(Enemy enemy)
    {
        _enemy = enemy;

        nameText.text = enemy.Base.Name;
        lvlText.text = "Lvl" + enemy.Level;
        hpBar.SetHP((float)enemy.HP / enemy.MaxHp);
    }

    public IEnumerator UpdateHPEnemy()
    {
        yield return hpBar.SetHPSmooth((float)_enemy.HP / _enemy.MaxHp);
    }

    public IEnumerator UpdateHPChar()
    {
        yield return hpBar.SetHPSmooth((float)_character.HP / _character.MaxHp);
    }
}
