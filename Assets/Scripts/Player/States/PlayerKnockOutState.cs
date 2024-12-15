using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerKnockOutState : IPlayerState
{

    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;
    //MeshRenderer original_position;

    public float counterKO = 0;
    public float maxCounterKO = 5;

    float GetUpBar = 0;
    float previousGetUpBar = 0;


    public PlayerKnockOutState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
        //original_position = 
    }


    public void ToHurtState(float damage)
    {
        throw new NotImplementedException();
    }

    public void UpdateState()
    {
        BattleManager.battleManager.EnemyPaused = true;
        player.indicator1.material.color = Color.black;
        player.indicator2.material.color = Color.black;
        player.indicator3.material.color = Color.black;

        //Debug.Log(timer);


        timer += Time.deltaTime;

        if (Input.GetKeyUp("space"))
            GetUpBar += 100;

        //GetUpBar -= 1.5f * GameManager.manager.knockoutsTotal+1; // getupbardecay
        GetUpBar -= 1.5f * player.knockoutsTotal+1; // getupbardecay
        //previousGetUpBar = player.fillerKO.fillAmount * 1000;
        //counterKO = 0;

        //updateFiller();


        if (GetUpBar < 0)
            GetUpBar = 0;

        player.fillerKO.fillAmount = GetUpBar/1000;

        Debug.Log(GetUpBar);

        if (timer > 10)
        {
            BattleManager.battleManager.KnockOutTimerTextField.text = "GAME OVER\n ENEMY WINS";
            BattleManager.battleManager.returnToMenu();

            //Debug.Log("enemy wins, play next oponent / whatever");
            return;
        }


        BattleManager.battleManager.KnockOutTimerTextField.text = Math.Floor(timer).ToString() + "\nPRESS SPACE TO GET UP!";


        if (GetUpBar > 1000)
        {
            GetUpBar = 0;
            player.indicator1.material.color = Color.white;
            player.indicator2.material.color = Color.white;
            player.indicator3.material.color = Color.white;

            player.fillerKO.fillAmount = 0;


            //GameManager.manager.health = (float)(GameManager.manager.maxHealth * (0.3 * (3 - GameManager.manager.knockoutsThisRound)));
            player.health = (float)(player.maxHealth * (0.3 * (3 - player.knockoutsThisRound)));

            if (player.health < 0)
                player.health = 1;

            //if (GameManager.manager.health < 0)
              //  GameManager.manager.health = 1;

            timer = 0;
            //BattleManager.battleManager.EnemyPaused = false;
            BattleManager.battleManager.KnockOutTimerTextField.text = "";
            BattleManager.battleManager.UIPanel.SetActive(false);
            BattleManager.battleManager.ResumeMatch = true;


            player._animator.SetBool("KnockOut",false);
            player._animator.ResetTrigger("KnockOutTrigger");
            player._animator.SetTrigger("KnockOutTrigger");
            //player._animator.ResetTrigger("KnockOutTrigger");


            player.currentState = player.neutralState;
            BattleManager.battleManager.PlayerPaused = true;
        }




    }

    public void updateFiller()
    {
        if (counterKO > maxCounterKO)
        {
            previousGetUpBar = GetUpBar;
            counterKO = 0;
        }
        else
        {
            counterKO += Time.deltaTime;
        }


        player.fillerKO.fillAmount = Mathf.Lerp(previousGetUpBar / 1000,
           GetUpBar / 1000, counterKO / maxCounterKO);
    }



}
