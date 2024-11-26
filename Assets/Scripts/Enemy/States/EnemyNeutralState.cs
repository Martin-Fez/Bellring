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
            enemyBoxer.currentState = enemyBoxer.enemyHurtState;
        }
        else
        {
            enemyBoxer.currentState = enemyBoxer.enemyBlockState;
        }
    }

    public void UpdateState()
    {
        timer += Time.deltaTime;
        timer = timer % 5;
        enemyBoxer.indicator1.material.color = Color.white;
        enemyBoxer.indicator2.material.color = Color.white;
        enemyBoxer.indicator3.material.color = Color.white;


        /*
        if(timer < 3f)
        {
            enemyBoxer.indicator3.material.color = Color.red;

        }
        else
            enemyBoxer.indicator3.material.color = Color.white;
        */



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
