using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralState : IPlayerState
{
    private StatePatternPlayer player;


    public NeutralState(StatePatternPlayer statePatternPlayer)
    {
        player = statePatternPlayer;
    }


    public void UpdateState()
    {

        player.indicator1.material.color = Color.white;
        player.indicator2.material.color = Color.white;
        player.indicator3.material.color = Color.white;

        //attacks

        if (Input.GetKeyDown("z") && !Input.GetKey("up"))
        {
            player.indicator1.material.color = Color.green;
            player.currentState = player.lJabState;
            return;
        }

        if (Input.GetKeyDown("x") && !Input.GetKey("up"))
        {
            player.indicator2.material.color = Color.green;
            player.currentState = player.rJabState;
            return;
        }

        if (Input.GetKeyDown("z") && Input.GetKey("up"))
        {
            player.indicator1.material.color = Color.red;
            player.currentState = player.lUpJabState;
            return;
        }

        if (Input.GetKeyDown("x") && Input.GetKey("up"))
        {
            player.indicator2.material.color = Color.red;
            player.currentState = player.rUpjabState;
            return;
        }


        // non attack segment

        if (Input.GetKeyDown("space")) // uppercut
        {
            player.indicator1.material.color = Color.red;
            player.indicator2.material.color = Color.red;
            player.indicator3.material.color = Color.red;
            player.currentState = player.upperCutState;
            return;
        }

        if (Input.GetKey("c")) // block
        {
            player.indicator3.material.color = Color.yellow;
            player.currentState = player.blockState;
            return;
        }


        if (Input.GetKeyDown("left")) 
        {
            player.indicator1.material.color = Color.blue;
            player.indicator3.material.color = Color.blue;
            player.currentState = player.leftDodgeState;
            return;
        }

        if (Input.GetKeyDown("right")) // block
        {
            player.indicator2.material.color = Color.blue;
            player.indicator3.material.color = Color.blue;
            player.currentState = player.rightDodgeState;
            return;
        }

        if (Input.GetKeyDown("down")) // block
        {
            player.indicator1.material.color = Color.blue;
            player.indicator2.material.color = Color.blue;
            player.indicator3.material.color = Color.blue;
            player.currentState = player.duckState;
            return;
        }




    }

    public void ToHurtState()
    {

    }
}
