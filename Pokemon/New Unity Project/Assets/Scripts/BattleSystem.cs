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
        SetUpBattle();

    }

    void SetUpBattle()
    {
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        dialogueText.text = "E' apparso un " + enemyUnit.unitName + " selvatico";

        enemyHUD.SetHUD(enemyUnit);
        playerHUD.SetHUD(playerUnit);
    }
}
