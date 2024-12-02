using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJabState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public LJabState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }

//    public LJabState(StatePatternPlayer statePatternPlayer)
  //  {
    //    player = statePatternPlayer;
  //  }
    public void UpdateState()
    {
        timer += Time.deltaTime;

        if(timer > 0.3f) // hard coded jab time
        {
            enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage,1); 
                
            player.currentState = player.neutralState;
            timer = 0;
        }
    }

    public void ToHurtState()
    {

    }
}
