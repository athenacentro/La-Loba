using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text lvlText;
    [SerializeField] HPBar hpBar;

    public void SetData(Enemy enemy)
    {
        nameText.text = enemy.Base.Name;
        lvlText.text = "Lvl" + enemy.Level;
        hpBar.SetHP((float) enemy.HP / enemy.MaxHp);
    }
}
