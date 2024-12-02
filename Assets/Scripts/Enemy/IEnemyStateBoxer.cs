using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStateBoxer
{


    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    */


    void UpdateState();


    void ToHurtState(float damage,int lowerAttack);
}
