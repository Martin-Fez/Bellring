using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDodgeState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;


    public RightDodgeState(StatePatternPlayer statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        timer += Time.deltaTime; // may need to check if this truly resets to 0 to toHurtCall

        if (timer > 0.5f) // hard coded jab time
        {
            player.currentState = player.neutralState;
            timer = 0;
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
            if (GameManager.manager.hearts <= 0)
                GameManager.manager.hearts = 15;

            return;
        }
    }

}
