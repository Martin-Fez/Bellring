using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class LUpJabState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;
    public const string STATE_ANIMATION = "PlayerJabLeft";


    public LUpJabState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }
    public void UpdateState()
    {
        if (player.currentAnimationState != STATE_ANIMATION)
        {
            //player._animator.Play(STATE_ANIMATION);
            //animator.CrossFade(“State Name”, fadeDuration);
            //player._animator.CrossFade(STATE_ANIMATION, 0.1f);
            player.currentAnimationState = STATE_ANIMATION;
            //animator.SetBool("Walk", false); // THIS IS BETTER
        }




        timer += Time.deltaTime;

        if (timer > 0.3f) // hard coded jab time
        {
            enemyBoxer.currentState.ToHurtState(player.playerStandartAttackDamage,0);
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
