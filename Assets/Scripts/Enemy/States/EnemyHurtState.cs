using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : IEnemyStateBoxer
{

    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public EnemyHurtState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }


    public void ToHurtState(float damage, int lowerAttack)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        Debug.Log("hurt state");


        timer += Time.deltaTime;
        enemyBoxer.indicator1.material.color = Color.grey;
        enemyBoxer.indicator2.material.color = Color.grey;
        enemyBoxer.indicator3.material.color = Color.grey;

        if (timer > 0.2f) // hard coded hurt state, change later
        {
            //player.currentState = player.neutralState;
            CalculateBlockingSwitch();
            timer = 0;


            if(GameManager.manager.enemyHealth <= 0)
            {
                GameManager.manager.enemyKnockoutsThisRound += 1;
                GameManager.manager.enemyKnockoutsTotal += 1;
                enemyBoxer.currentState = enemyBoxer.enemyKnockoutState;
                return; // without return it continues
                //Debug.Log("THIS SHOULD NOT SHOW");
            }



            enemyBoxer.currentState = enemyBoxer.enemyNeutralState; // REMOVE LATER
            return;
        }
    }


    void CalculateBlockingSwitch() // checks how many times boxer has been hit and switches the blocking stance
    {
        enemyBoxer.hitsBeforeSwitch -= 1;
        if (enemyBoxer.hitsBeforeSwitch == 0)
        {
            enemyBoxer.hitsBeforeSwitch = 2; // will change
            enemyBoxer.blockingLower = !enemyBoxer.blockingLower;
            enemyBoxer._animator.SetBool("BlockLow", enemyBoxer.blockingLower);


            if (enemyBoxer.blockingLower)
            {
                enemyBoxer.indicator4_Body.material.color = Color.green;
                //animator.SetBool("Walk", false);

            }
            else
            {

                enemyBoxer.indicator4_Body.material.color = Color.red;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
