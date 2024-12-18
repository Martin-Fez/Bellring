using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialState : IEnemyStateBoxer
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;

    bool hasBlocked = false; // boolean to prevent spamming



    public EnemySpecialState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }


    public void ToHurtState(float damage, int lowerAttack)
    {
        if(timer < 3) // misses the enemy
        {
            player.hearts -= 1;
            Debug.Log("Miss");

            return;
        }


        //if ( (lowerAttack == 2 || (Convert.ToBoolean(lowerAttack) != enemyBoxer.blockingLower || timer >  ) && timer > 0.1f)) // if uppercut or lowerattack and block do not match
        if ((lowerAttack == 2 || timer > 4f) && !hasBlocked) // if  timer is not above 0.1 he will block
        {

            if (timer < 4.1f)
                enemyBoxer.TakeDamage(enemyBoxer.enemyHealth);

            enemyBoxer.TakeDamage(damage*5);
            if (lowerAttack != 2)
                player.stars++;

            enemyBoxer.hitsBeforeSwitch = 6;
            enemyBoxer.hasBeenHit = true;

            timer = 0;
            enemyBoxer._animator.SetTrigger("Hurt");
            SoundFXManager.instace.PlaySoundFXclip(enemyBoxer.GotHit, enemyBoxer.transform, 1f);

            enemyBoxer.currentState = enemyBoxer.enemyHurtState;
        }
        else // block logic, works diffrent for attacks
        {
            SoundFXManager.instace.PlaySoundFXclip(enemyBoxer.Block, enemyBoxer.transform, 1f);

            player.hearts -= 1;
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
        enemyBoxer.indicator3.material.color = Color.white;
        enemyBoxer.indicator4_Body.material.color = Color.white;

        if (timer < 3f)
        {
            enemyBoxer.indicator1.material.color = Color.blue;
            enemyBoxer.indicator2.material.color = Color.blue;
            enemyBoxer.indicator3.material.color = Color.blue;
            enemyBoxer.indicator4_Body.material.color = Color.blue;

        }

        if(timer > 4f)
        {
            //enemyBoxer.indicator1.material.color = Color.;
            //enemyBoxer.indicator2.material.color = Color.yellow;
            enemyBoxer.indicator3.material.color = Color.yellow;
            enemyBoxer.indicator4_Body.material.color = Color.yellow;
        }



        if (timer > 4.5f) // hard coded hurt state, change later
        {
            //player.currentState = player.neutralState;
            //CalculateBlockingSwitch();


            //enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage, 1);
            player.currentState.ToHurtState(11);
            timer = 0;
            hasBlocked = false;

            enemyBoxer.hitsBeforeSwitch = 4;

            // NEW STATE?
            enemyBoxer.currentState = enemyBoxer.enemyNeutralState; // REMOVE LATER
        }
    }
}
