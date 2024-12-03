using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RJabState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public RJabState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }

    public void UpdateState()
    {
        timer += Time.deltaTime;

        if (timer > 0.3f) // hard coded jab time
        {
            enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage,1);
            player.currentState = player.neutralState;
            timer = 0;
        }
    }


    public void ToHurtState(float damage)
    {

        timer = 0;
        player._animator.SetTrigger("Hurt");
        player.TakeDamage(damage);
        player.currentState = player.hurtState;

    }
}
