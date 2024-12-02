using System;
using System.Collections;
using System.Collections.Generic;
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

        if( lowerAttack == 2 || (Convert.ToBoolean(lowerAttack) != enemyBoxer.blockingLower)) // if uppercut or lowerattack and block do not match
        {
            //timer = 0;
            enemyBoxer.TakeDamage(damage);
            enemyBoxer._animator.SetTrigger("Hurt");
            enemyBoxer.currentState = enemyBoxer.enemyHurtState;
        }
        else
        {
            enemyBoxer._animator.SetTrigger("Block");

            enemyBoxer.currentState = enemyBoxer.enemyBlockState;
        }
    }

    public void UpdateState()
    {
        Debug.Log("Neutral state");


        //timer += Time.deltaTime; // standart
        timer = GameManager.manager.FightTimer;
        timer = timer % 5;
        enemyBoxer.indicator1.material.color = Color.white;
        enemyBoxer.indicator2.material.color = Color.white;
        enemyBoxer.indicator3.material.color = Color.white;


        
        //if(timer > 3f && timer < 4f && !enemyBoxer.debug_Hit)
        if(timer > 3f && timer < 3.1f)
        {
            //enemyBoxer.debug_Hit = true;
            enemyBoxer.indicator3.material.color = Color.red;
            enemyBoxer._animator.ResetTrigger("RightHook");
            enemyBoxer._animator.SetTrigger("RightHook");
            enemyBoxer.currentState = enemyBoxer.enemyHookState;

            //enemyBoxer

        }
        else
            enemyBoxer.indicator3.material.color = Color.white;

        //if (timer > 4f)
            //enemyBoxer.debug_Hit = false;
        



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
