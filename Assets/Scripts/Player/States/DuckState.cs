using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public DuckState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }
    public void UpdateState()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f) // hard coded jab time
        {
            player.currentState = player.neutralState;
            timer = 0;
            //enemyBoxer.currentState = enemyBoxer.enemyHurtState; // REMOVE LATER, will also call the enemy to hurt function
        }
    }


    public void ToHurtState(float damage) // may need a second variable for future attacks
    {
        if (timer < 0.1f) // we are too slow
        {
            timer = 0;
            player._animator.SetTrigger("Hurt");
            player.TakeDamage(damage);
            player.currentState = player.hurtState;
        }
        else
        {
            // we dodged, return
            if(GameManager.manager.hearts <= 0)
                GameManager.manager.hearts = 15;

            return;

        }

    }
}
