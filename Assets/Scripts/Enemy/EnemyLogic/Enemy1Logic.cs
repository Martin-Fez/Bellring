using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1Logic : IEnemyLogic
{

    public StatePatternEnemyBoxer enemyBoxer;

    public float timer = 0;
    public float maxTimer;



    //public IEnemyStateBoxer returnNextState()
    //protected override IEnemyStateBoxer returnNextState()

    public override IEnemyStateBoxer returnNextState()
    {
        enemyBoxer.stateCooldown += Time.deltaTime; // may add this uptick to enemy hurt

        if(enemyBoxer.stateCooldown > enemyBoxer.MaxstateCooldown)
        {
            enemyBoxer.stateCooldown = enemyBoxer.MaxstateCooldown;
        }

        //Debug.Log("in logic");

        timer = BattleManager.battleManager.FightTimer % maxTimer;
        IEnemyStateBoxer nextState = enemyBoxer.enemyNeutralState;

        if (enemyBoxer.stateCooldown < enemyBoxer.MaxstateCooldown)
            return nextState;

        //Debug.Log("in logic2");


        if (BattleManager.battleManager.round == 1 && BattleManager.battleManager.FightTimer < 35)
        {
            return nextState;
        }
        //Debug.Log("in logic3");

        SoundFXManager.instace.PlaySoundFXclip(enemyBoxer.Block, enemyBoxer.transform, 1f);



        if ((timer > 3f && timer < 6f) || (timer > 12f && timer < 15f))
        {
            //enemyBoxer.debug_Hit = true;
            //Debug.Log("in logic4");

            enemyBoxer.stateCooldown = 0;
            return hookAttack();

        }


        if (timer > 6f && timer < 12f)
        {
            //Debug.Log("in logic5");

            enemyBoxer.stateCooldown = 0;

            return jabAttack();

        }



        if (timer > 15f && timer < 20f)
        {
            //Debug.Log("in logic6");

            enemyBoxer.stateCooldown = 0;
            return specialAttack();

        }

        return nextState;

    }


    IEnemyStateBoxer specialAttack()
    {
        // insert other things here
        enemyBoxer._animator.ResetTrigger("Special");
        enemyBoxer._animator.SetTrigger("Special");


         return enemyBoxer.enemySpecialState;
    }

    IEnemyStateBoxer hookAttack()
    {
        enemyBoxer.indicator3.material.color = Color.red;
        enemyBoxer._animator.ResetTrigger("RightHook");
        enemyBoxer._animator.SetTrigger("RightHook");
        return enemyBoxer.enemyHookState;
    }

    IEnemyStateBoxer jabAttack()
    {
        enemyBoxer.indicator3.material.color = Color.red;
        enemyBoxer._animator.ResetTrigger("Jab");
        enemyBoxer._animator.SetTrigger("Jab");
        return enemyBoxer.enemyJabState;
    }

}
