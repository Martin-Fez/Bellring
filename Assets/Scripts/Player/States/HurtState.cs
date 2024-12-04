using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;


    public HurtState(StatePatternPlayer statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        timer += Time.deltaTime;
        player.indicator1.material.color = Color.red;
        player.indicator2.material.color = Color.red;
        player.indicator3.material.color = Color.red;

        if (timer > 0.5f) 
        {
            timer = 0;


            if (player.health <= 0)
            {
                player.knockoutsThisRound += 1;
                player.knockoutsTotal += 1;
                player.currentState = player.knockOutState;
                return; // without return it continues
                //Debug.Log("THIS SHOULD NOT SHOW");
            }


            player.currentState = player.neutralState;
        }
    }

    public void ToHurtState(float damage)
    {
        timer = 0;
        player._animator.ResetTrigger("Hurt");
        player._animator.SetTrigger("Hurt");
        // cannot enter this
    }
}
