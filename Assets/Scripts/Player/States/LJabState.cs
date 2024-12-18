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
            if (!player.LastPunchLeft)
                enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage * 1.5f, 1);
            else
                enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage, 1);

            player.LastPunchLeft = true;
            timer = 0;
            player.currentState = player.neutralState;
        }
    }


    public void ToHurtState(float damage)
    {

        timer = 0;
        player.hearts--;
        SoundFXManager.instace.PlaySoundFXclip(player.GotHit, player.transform, 1f);
        player._animator.SetTrigger("Hurt");
        player.TakeDamage(damage);
        player.currentState = player.hurtState;

    }
}
