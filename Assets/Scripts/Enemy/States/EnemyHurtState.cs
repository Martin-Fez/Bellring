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


    public void ToHurtState()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState()
    {
        timer += Time.deltaTime;
        enemyBoxer.indicator1.material.color = Color.grey;
        enemyBoxer.indicator2.material.color = Color.grey;
        enemyBoxer.indicator3.material.color = Color.grey;

        if (timer > 0.2f) // hard coded hurt state, change later
        {
            //player.currentState = player.neutralState;
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
