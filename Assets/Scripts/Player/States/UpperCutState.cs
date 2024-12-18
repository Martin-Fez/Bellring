using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperCutState : IPlayerState // AKA player special attack
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public UpperCutState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }
    public void UpdateState()
    {
        timer += Time.deltaTime;

        if (timer > 1f) // hard coded jab time
        {
            enemyBoxer.currentState.ToHurtState(player.PlayerSpecialAttackDamage, 2); // special state will have to check for it
            player.currentState = player.neutralState;
            timer = 0;
        }
    }


    public void ToHurtState(float damage)
    {

        timer = 0;
        SoundFXManager.instace.PlaySoundFXclip(player.GotHit, player.transform, 1f);
        player._animator.SetTrigger("Hurt");
        player.TakeDamage(damage);
        player.hearts--;
        player.currentState = player.hurtState;

    }
}
