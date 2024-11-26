using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUpJabState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public RUpJabState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }

    public void UpdateState()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f) // hard coded jab time
        {
            enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage,0);
            player.currentState = player.neutralState;
            timer = 0;
        }
    }

    public void ToHurtState()
    {

    }
}
