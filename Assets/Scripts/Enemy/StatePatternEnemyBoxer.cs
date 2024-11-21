using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StatePatternEnemyBoxer : MonoBehaviour
{
    public MeshRenderer indicator1;
    public MeshRenderer indicator2;
    public MeshRenderer indicator3;

    //public int hearts = 30; // if this hits 0, player becomes tired

    public Image filler; // this is the image. we\ll adjust fillamount value

    //public string playerName;
    public StatePatternPlayer player;

    public TMP_Text healthField;
    //public TMP_Text nameField;


    //[HideInInspector] public Transform chaseTarget; // This is what we chase in chase state. Usually Player.
    [HideInInspector] public IEnemyStateBoxer currentState;
    [HideInInspector] public EnemyBlockState enemyBlockState;
    [HideInInspector] public EnemyHookState enemyHookState;
    [HideInInspector] public EnemyHurtState enemyHurtState;
    [HideInInspector] public EnemyJabState enemyJabState;
    [HideInInspector] public EnemyNeutralState enemyNeutralState;
    [HideInInspector] public EnemySpecialState enemySpecialState;



    private void Awake()
    {
        /*
        neutralState = new NeutralState(this);
        duckState = new DuckState(this);
        blockState = new BlockState(this);
        leftDodgeState = new LeftDodgeState(this);
        rightDodgeState = new RightDodgeState(this);
        rJabState = new RJabState(this);
        lJabState = new LJabState(this);
        rUpjabState = new RUpJabState(this);
        lUpJabState = new LUpJabState(this);
        upperCutState = new UpperCutState(this);
        hurtState = new HurtState(this);
        */
        enemyBlockState = new EnemyBlockState();
        enemyHookState = new EnemyHookState();
        enemyHurtState = new EnemyHurtState(player,this);
        enemyJabState = new EnemyJabState();
        enemyNeutralState = new EnemyNeutralState(player, this);
        enemySpecialState = new EnemySpecialState();

    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = enemyNeutralState;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateManager(); // will maybe call if needed
        // we will update according to the state
        currentState.UpdateState();






    }

    public void UpdateManager()
    {
        healthField.text = GameManager.manager.enemyHealth.ToString();
    }

}
