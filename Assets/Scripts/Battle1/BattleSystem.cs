using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy }

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    int currentAction;
    int currentMove;

    BattleState state;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.SetupCharacter();
        playerHud.SetDataChar(playerUnit.Character);

        enemyUnit.SetupEnemy();
        enemyHud.SetDataEnem(enemyUnit.Enemy);

        dialogBox.SetMoveNames(playerUnit.Character.Moves);

        yield return (dialogBox.TypeDialog("DANGER! \nRaccoons can be extremely violent creatures and will forge a turmoil to Ashina's state. They are about to challenge Ashina?s perception of herself..."));

        yield return new WaitForSeconds(7f);

        yield return (dialogBox.TypeDialog("Combatting the raccoons can create a positive impact for Ashina. She will learn the ability to be resourceful through trusting herself and sourcing out her own subconscious to bring forth anything she puts her mind to."));

        yield return new WaitForSeconds(6f);
        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action: \n Use Z key to Enter."));
        dialogBox.EnableActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;

        var move = playerUnit.Character.Moves[currentMove];
        yield return dialogBox.TypeDialog($"{playerUnit.Character.Base.Name} used {move.Base.Name}.");

        playerUnit.PlayAttackAnimation();

        yield return new WaitForSeconds(1f);

        enemyUnit.PlayHitAnimation();

        var enemDamageDetails = enemyUnit.Enemy.TakeDamage(move, playerUnit.Character);
        yield return enemyHud.UpdateHPEnemy();

        if (enemDamageDetails.Critical > 1f)
        {
            yield return new WaitForSeconds(1f);
            yield return dialogBox.TypeDialog("A critical hit!");
        }

        if (enemDamageDetails.TypeEffectiveness > 1f)
        {
            yield return new WaitForSeconds(1f);
            yield return dialogBox.TypeDialog("An effective move!");
        }
        else if (enemDamageDetails.TypeEffectiveness < 1f)
        {
            yield return new WaitForSeconds(1f);
            yield return dialogBox.TypeDialog("Hmm...");
        }

        yield return new WaitForSeconds(1f);

        if (enemDamageDetails.Fainted)
        {
            yield return dialogBox.TypeDialog($"{enemyUnit.Enemy.Base.Name} fainted...");
            enemyUnit.PlayFaintAnimation();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("2ndLevel");
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;

        var move = enemyUnit.Enemy.GetRandomMove();
        yield return dialogBox.TypeDialog($"{enemyUnit.Enemy.Base.Name} used {move.Base.Name}.");

        enemyUnit.PlayAttackAnimation();

        yield return new WaitForSeconds(1f);

        playerUnit.PlayHitAnimation();

        var charDamageDetails = playerUnit.Character.TakeDamage(move, enemyUnit.Enemy);
        yield return playerHud.UpdateHPChar();
        yield return new WaitForSeconds(1f);

        if (charDamageDetails.Fainted)
        {
            yield return dialogBox.TypeDialog($"{playerUnit.Character.Base.Name} fainted...");
            playerUnit.PlayFaintAnimation();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("1stLevel");
        }
        else
        {
            PlayerAction();
        }
    }

    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }


    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                ++currentAction;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
            {
                --currentAction;
            }
        }

        dialogBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                PlayerMove();
            }
            else if (currentAction == 1)
            {
                //Run
            }
        }
    }

    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Character.Moves.Count - 1)
            {
                ++currentMove;
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
                --currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < playerUnit.Character.Moves.Count - 2)
            {
                currentMove += 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 1)
            {
                currentMove -= 2;
            }
        }

        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Character.Moves[currentMove]);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.EnableMoveSelector(false);
            dialogBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
