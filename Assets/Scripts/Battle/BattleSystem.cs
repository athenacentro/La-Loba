using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud enemyHud;

    private void Start()
    {
        SetupBattle();
    }

    public void SetupBattle()
    {
        enemyUnit.Setup();
        enemyHud.SetData(enemyUnit.Enemy);
    }
}
