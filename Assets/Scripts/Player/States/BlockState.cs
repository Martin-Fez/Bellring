using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState : IPlayerState
{
    //float timer = 0;
    private StatePatternPlayer player;


    public BlockState(StatePatternPlayer statePatternPlayer)
    {
        player = statePatternPlayer;
    }
    public void UpdateState()
    {
        //timer += Time.deltaTime;


        if (Input.GetKeyUp("c") || GameManager.manager.hearts == 0) // add running out of hearts as a condition
        {
            player._animator.SetTrigger("ReturnToIdle");
            player.currentState = player.neutralState;

            //timer = 0;
        }
    }


    public void ToHurtState(float damage)
    {

        //timer = 0;
        //player._animator.SetTrigger("Hurt");
        //player.TakeDamage(damage);
        //player.currentState = player.hurtState;
        
        // could make an extra animation here
        GameManager.manager.hearts--;

        return;

    }
}
