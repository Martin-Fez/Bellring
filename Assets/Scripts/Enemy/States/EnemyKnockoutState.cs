using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockoutState : IEnemyStateBoxer
{

    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public EnemyKnockoutState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }


    public void ToHurtState(float damage, int lowerAttack)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        BattleManager.battleManager.PlayerPaused = true;
        enemyBoxer.indicator1.material.color = Color.black;
        enemyBoxer.indicator2.material.color = Color.black;
        enemyBoxer.indicator3.material.color = Color.black;
        enemyBoxer.indicator4_Body.material.color = Color.black;

        //Debug.Log(timer);


        timer += Time.deltaTime;


        if (timer > 10)
        {
            BattleManager.battleManager.KnockOutTimerTextField.text = "PLAYER WINS";

            Debug.Log("Player wins, play next oponent / whatever");
            return;
        }





        BattleManager.battleManager.KnockOutTimerTextField.text = "ENEMY DOWN\n" + (Math.Floor(timer) + 1).ToString();

        if (timer > 3 * enemyBoxer.enemyKnockoutsThisRound && enemyBoxer.enemyKnockoutsThisRound <3 )
        {
            enemyBoxer.enemyHealth = (float)(enemyBoxer.enemyMaxHealth * (0.3 * (3 - enemyBoxer.enemyKnockoutsThisRound)));
            timer = 0;
            //BattleManager.battleManager.PlayerPaused = false;
            BattleManager.battleManager.KnockOutTimerTextField.text = "";


            BattleManager.battleManager.UIPanel.SetActive(false);

            enemyBoxer._animator.SetBool("KnockOut", false);

            BattleManager.battleManager.ResumeMatch = true;

            enemyBoxer._animator.ResetTrigger("KnockOutTrigger");
            enemyBoxer._animator.SetTrigger("KnockOutTrigger");



            enemyBoxer.currentState = enemyBoxer.enemyNeutralState;
            BattleManager.battleManager.EnemyPaused = true; // could break but hope not

        }




    }



}
