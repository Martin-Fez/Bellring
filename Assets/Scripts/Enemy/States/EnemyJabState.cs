using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJabState : IEnemyStateBoxer
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;

    bool hasBlocked = false; // boolean to prevent spamming



    public EnemyJabState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }


    public void ToHurtState(float damage, int lowerAttack)
    {
        //if ( (lowerAttack == 2 || (Convert.ToBoolean(lowerAttack) != enemyBoxer.blockingLower || timer >  ) && timer > 0.1f)) // if uppercut or lowerattack and block do not match
        if ((lowerAttack == 2 || timer > 0.3f) && !hasBlocked) // if  timer is not above 0.1 he will block
        {
            timer = 0;
            enemyBoxer.TakeDamage(damage);
            enemyBoxer.hitsBeforeSwitch = 5;
            enemyBoxer.hasBeenHit = true;

            enemyBoxer._animator.SetTrigger("Hurt");
            enemyBoxer.currentState = enemyBoxer.enemyHurtState;
        }
        else // block logic, works diffrent for attacks
        {
            enemyBoxer.indicator1.material.color = Color.red;
            enemyBoxer.indicator2.material.color = Color.red;
            enemyBoxer.indicator3.material.color = Color.red;
            enemyBoxer.indicator4_Body.material.color = Color.red;

            //enemyBoxer._animator.SetTrigger("Block");
            hasBlocked = true;

            //enemyBoxer.currentState = enemyBoxer.enemyBlockState;
        }
    }

    public void UpdateState()
    {
        //Debug.Log("hook state");

        timer += Time.deltaTime;
        enemyBoxer.indicator1.material.color = Color.cyan;
        enemyBoxer.indicator2.material.color = Color.cyan;
        enemyBoxer.indicator3.material.color = Color.cyan;

        if (timer > 0.8f) // hard coded hurt state, change later
        {
            //player.currentState = player.neutralState;
            //CalculateBlockingSwitch();


            //enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage, 1);
            player.currentState.ToHurtState(11);
            timer = 0;
            hasBlocked = false;
            enemyBoxer.currentState = enemyBoxer.enemyNeutralState; // REMOVE LATER
        }
    }
}
