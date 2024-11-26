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
        enemyBoxer.indicator1.material.color = Color.black;
        enemyBoxer.indicator2.material.color = Color.black;
        enemyBoxer.indicator3.material.color = Color.black;
        enemyBoxer.indicator4_Body.material.color = Color.black;

        Debug.Log(timer);


        timer += Time.deltaTime;
        if(timer > 3 * GameManager.manager.enemyKnockoutsThisRound && GameManager.manager.enemyKnockoutsThisRound <3 )
        {
            GameManager.manager.enemyHealth = (float)(GameManager.manager.enemyMaxHealth * (0.3 * (3 - GameManager.manager.enemyKnockoutsThisRound)));
            timer = 0;
            enemyBoxer.currentState = enemyBoxer.enemyNeutralState;
        }

        if(timer > 10)
        {
            Debug.Log("Player wins, play next oponent / whatever");
        }


    }



}
