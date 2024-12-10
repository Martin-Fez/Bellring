using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyNeutralState : IEnemyStateBoxer
{

    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;




    public EnemyNeutralState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }

    public void ToHurtState(float damage, int lowerAttack)
    {

        if( lowerAttack == 2 || (Convert.ToBoolean(lowerAttack) != enemyBoxer.blockingLower) || enemyBoxer.hasBeenHit) // if uppercut or lowerattack and block do not match
        {
            //timer = 0;

            enemyBoxer.TakeDamage(damage); // BIG DAMAGE
            enemyBoxer._animator.SetTrigger("Hurt");
            enemyBoxer.currentState = enemyBoxer.enemyHurtState;
        }
        else
        {
        Debug.Log("BLock neutral");

            player.hearts -= 1;
            enemyBoxer._animator.SetTrigger("Block");

            enemyBoxer.currentState = enemyBoxer.enemyBlockState;
        }
    }

    public void UpdateState()
    {
        //Debug.Log("Neutral state");


        //timer += Time.deltaTime; // standart
        timer = BattleManager.battleManager.FightTimer;
        timer = timer % 20;
        enemyBoxer.indicator1.material.color = Color.white;
        enemyBoxer.indicator2.material.color = Color.white;
        enemyBoxer.indicator3.material.color = Color.white;
        enemyBoxer.indicator4_Body.material.color = Color.white;



        //if(timer > 3f && timer < 4f && !enemyBoxer.debug_Hit)

        //*

        if(BattleManager.battleManager.round == 1 && BattleManager.battleManager.FightTimer < 40)
        {
            return;
        }


        
        if (timer > 3f && timer < 3.1f)
        {
            //enemyBoxer.debug_Hit = true;
            hookAttack();

            //enemyBoxer

        }


        if(timer > 6f && timer < 6.1f)
        {
            jabAttack();

        }


        if (timer > 9f && timer < 9.1f)
        {
            //enemyBoxer.debug_Hit = true;
            hookAttack();

            //enemyBoxer

        }


        if (timer > 12f && timer < 12.1f)
        {
            hookAttack();
        }

        //*/

        if (timer > 18f && timer < 18.1f)
        {

            specialAttack();

        }
        
        

        //if (timer > 4f)
        //enemyBoxer.debug_Hit = false;




    }


    void specialAttack()
    {
        // insert other things here
        enemyBoxer._animator.ResetTrigger("Special");
        enemyBoxer._animator.SetTrigger("Special");


        enemyBoxer.currentState = enemyBoxer.enemySpecialState;
    }

    void hookAttack()
    {
        enemyBoxer.indicator3.material.color = Color.red;
        enemyBoxer._animator.ResetTrigger("RightHook");
        enemyBoxer._animator.SetTrigger("RightHook");
        enemyBoxer.currentState = enemyBoxer.enemyHookState;
    }

    void jabAttack()
    {
        enemyBoxer.indicator3.material.color = Color.red;
        enemyBoxer._animator.ResetTrigger("Jab");
        enemyBoxer._animator.SetTrigger("Jab");
        enemyBoxer.currentState = enemyBoxer.enemyJabState;
    }


    // Start is called before the first frame update
    /*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
    }
