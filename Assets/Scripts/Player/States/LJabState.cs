using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LJabState : IPlayerState
{
    float timer = 0;
    private StatePatternPlayer player;


    public LJabState(StatePatternPlayer statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        timer += Time.deltaTime;

        if(timer > 0.5f) // hard coded jab time
        {
            player.currentState = player.neutralState;
            timer = 0;
        }
    }

    public void ToHurtState()
    {

    }
}
