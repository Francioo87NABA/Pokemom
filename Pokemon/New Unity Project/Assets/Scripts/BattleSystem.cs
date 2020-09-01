using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    Unit enemyUnit;
    Unit playerUnit;

    public Transform enemyBattleStation;
    public Transform playerBattleStation;

    public BattleHUD enemyHUD;
    public BattleHUD playerHUD;

    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle()); 

    }

    IEnumerator SetUpBattle()
    {
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation.position, enemyBattleStation.rotation, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation.position, playerBattleStation.rotation, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        dialogueText.text = "e apparso un "; //+ enemyUnit.unitName + " selvatico";

        Debug.Log("diocane");

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Cosa fare?";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) 
        return;

        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.unitDamage);

        enemyHUD.SetHP(enemyUnit.currentHp);

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            ;
        }
        else
        {
            ;
        }
    }
}
