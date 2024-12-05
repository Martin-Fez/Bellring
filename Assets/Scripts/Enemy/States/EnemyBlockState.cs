using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockState : IEnemyStateBoxer
{

    float timer = 0;
    private StatePatternPlayer player;
    private StatePatternEnemyBoxer enemyBoxer;


    public EnemyBlockState(StatePatternPlayer statePatternPlayer, StatePatternEnemyBoxer StatePatternEnemyBoxer)
    {
        player = statePatternPlayer;
        enemyBoxer = StatePatternEnemyBoxer;
    }


    public void ToHurtState(float damage, int lowerAttack)
    {

        player.hearts -= 1;
        Debug.Log("funny attack block");
        return; //Nothing happens
        //throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        timer += Time.deltaTime;
        enemyBoxer.indicator1.material.color = Color.red;
        enemyBoxer.indicator2.material.color = Color.red;
        enemyBoxer.indicator3.material.color = Color.red;

        if (timer > 0.2f) // hard coded hurt state, change later
        {
            //player.currentState = player.neutralState;
            //CalculateBlockingSwitch();


            enemyBoxer.hitsBeforeSwitch = 2;
            timer = 0;
            enemyBoxer.currentState = enemyBoxer.enemyNeutralState; // REMOVE LATER
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
