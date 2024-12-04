using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
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


    // checks if we switch to hurtState, if yes, reset any values and change state to hurt state
    void ToHurtState(float damage);


    //void removeStar();

    //void removeHeart();
}
