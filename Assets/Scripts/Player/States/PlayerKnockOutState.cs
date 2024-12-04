using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockOutState : IPlayerState
{

    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;
    //MeshRenderer original_position;



    float GetUpBar = 0;


    public PlayerKnockOutState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
        //original_position = 
    }


    public void ToHurtState(float damage)
    {
        throw new NotImplementedException();
    }

    public void UpdateState()
    {
        GameManager.manager.EnemyPaused = true;
        player.indicator1.material.color = Color.black;
        player.indicator2.material.color = Color.black;
        player.indicator3.material.color = Color.black;

        //Debug.Log(timer);


        timer += Time.deltaTime;
        GameManager.manager.KnockOutTimerTextField.text = Math.Floor(timer).ToString();

        if (Input.GetKeyUp("space"))
            GetUpBar += 100;

        //GetUpBar -= 1.5f * GameManager.manager.knockoutsTotal+1; // getupbardecay
        GetUpBar -= 1.5f * player.knockoutsTotal+1; // getupbardecay

        if (GetUpBar < 0)
            GetUpBar = 0;

        Debug.Log(GetUpBar);

        if (timer > 10)
        {
            Debug.Log("enemy wins, play next oponent / whatever");
            return;
        }

        if (GetUpBar > 1000)
        {
            GetUpBar = 0;
            player.indicator1.material.color = Color.white;
            player.indicator2.material.color = Color.white;
            player.indicator3.material.color = Color.white;


            //GameManager.manager.health = (float)(GameManager.manager.maxHealth * (0.3 * (3 - GameManager.manager.knockoutsThisRound)));
            player.health = (float)(player.maxHealth * (0.3 * (3 - player.knockoutsThisRound)));

            if (player.health < 0)
                player.health = 1;

            //if (GameManager.manager.health < 0)
              //  GameManager.manager.health = 1;

            timer = 0;
            GameManager.manager.EnemyPaused = false;
            GameManager.manager.KnockOutTimerTextField.text = "";

            player.currentState = player.neutralState;
        }




    }



}
