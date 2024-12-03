using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralState : IPlayerState
{
    private StatePatternPlayer player;
    public const string STATE_ANIMATION = "PlayerIdle";

    public NeutralState(StatePatternPlayer statePatternPlayer)
    {
        player = statePatternPlayer;
    }


    public void UpdateState()
    {
        //player._Animator.Play(PLAYER_IDLE);
        /*
        if(player.currentAnimationState != STATE_ANIMATION)
        {
            player._animator.Play(STATE_ANIMATION);
            player.currentAnimationState = STATE_ANIMATION;
        }
        */
        player._animator.SetTrigger("Idle");


        player.indicator1.material.color = Color.white;
        player.indicator2.material.color = Color.white;
        player.indicator3.material.color = Color.white;

        //attacks

        if (Input.GetKeyDown("z") && !Input.GetKey("up"))
        {
            player.indicator1.material.color = Color.green;
            player._animator.SetTrigger("BodyBlowLeft");
            player.currentState = player.lJabState;
            return;
        }

        if (Input.GetKeyDown("x") && !Input.GetKey("up"))
        {
            player.indicator2.material.color = Color.green;
            player._animator.SetTrigger("BodyBlowRight");

            player.currentState = player.rJabState;
            return;
        }

        if (Input.GetKeyDown("z") && Input.GetKey("up"))
        {
            player.indicator1.material.color = Color.red;
            player._animator.SetTrigger("JabLeft");
            player.currentState = player.lUpJabState;
            return;
        }



        if (Input.GetKeyDown("x") && Input.GetKey("up"))
        {
            player.indicator2.material.color = Color.red;
            player._animator.SetTrigger("JabRight");

            player.currentState = player.rUpjabState;
            return;
        }


        // non attack segment

        if (Input.GetKeyDown("space")) // uppercut
        {
            player.indicator1.material.color = Color.red;
            player.indicator2.material.color = Color.red;
            player.indicator3.material.color = Color.red;
            player._animator.SetTrigger("UpperCut");

            player.currentState = player.upperCutState;
            return;
        }

        if (Input.GetKey("c")) // block
        {
            player.indicator3.material.color = Color.yellow;
            player._animator.ResetTrigger("ReturnToIdle");
            player._animator.SetTrigger("Block");
            player.currentState = player.blockState;
            return;
        }


        if (Input.GetKeyDown("left")) 
        {
            player.indicator1.material.color = Color.blue;
            player.indicator3.material.color = Color.blue;
            player._animator.SetTrigger("DodgeLeft");

            player.currentState = player.leftDodgeState;
            return;
        }

        if (Input.GetKeyDown("right")) // block
        {
            player.indicator2.material.color = Color.blue;
            player.indicator3.material.color = Color.blue;
            player._animator.SetTrigger("DodgeRight");

            player.currentState = player.rightDodgeState;
            return;
        }

        if (Input.GetKeyDown("down")) // block
        {
            player.indicator1.material.color = Color.blue;
            player.indicator2.material.color = Color.blue;
            player.indicator3.material.color = Color.blue;
            player._animator.SetTrigger("Duck");

            player.currentState = player.duckState;
            return;
        }




    }

    public void ToHurtState(float damage)
    {

        //timer = 0;
        player._animator.SetTrigger("Hurt");
        player.TakeDamage(damage);
        player.currentState = player.hurtState;

        /*
        if (lowerAttack == 2 || (Convert.ToBoolean(lowerAttack) != enemyBoxer.blockingLower)) // if uppercut or lowerattack and block do not match
        {
            //timer = 0;
            enemyBoxer.TakeDamage(damage);
            enemyBoxer._animator.SetTrigger("Hurt");
            enemyBoxer.currentState = enemyBoxer.enemyHurtState;
        }
        else
        {
            enemyBoxer._animator.SetTrigger("Block");

            enemyBoxer.currentState = enemyBoxer.enemyBlockState;
        }
        */
    }
}
