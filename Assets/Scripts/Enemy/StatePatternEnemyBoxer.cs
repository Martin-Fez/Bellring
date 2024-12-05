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
    public MeshRenderer indicator4_Body;

    public Animator _animator;
    //public string currentAnimationState = "";

    //public bool debug_Hit;



    public int hitsBeforeSwitch; // how many hits can the boxer take before he starts blocking there
    public bool hasBeenHit = false;

    public bool blockingLower;


    //public int hearts = 30; // if this hits 0, player becomes tired

    public Image filler; // this is the image. we\ll adjust fillamount value

    //public string playerName;
    public StatePatternPlayer player;

    public TMP_Text healthField;
    //public TMP_Text nameField;



    public float enemyHealth;
    public float enemyPreviousHealth;
    public float enemyMaxHealth;
    public int enemyKnockoutsThisRound; // how many times the ENEMY has been knockouted
    public int enemyKnockoutsTotal;


    //[HideInInspector] public Transform chaseTarget; // This is what we chase in chase state. Usually Player.
    [HideInInspector] public IEnemyStateBoxer currentState;
    [HideInInspector] public EnemyBlockState enemyBlockState;
    [HideInInspector] public EnemyHookState enemyHookState;
    [HideInInspector] public EnemyHurtState enemyHurtState;
    [HideInInspector] public EnemyJabState enemyJabState;
    [HideInInspector] public EnemyNeutralState enemyNeutralState;
    [HideInInspector] public EnemySpecialState enemySpecialState;
    [HideInInspector] public EnemyKnockoutState enemyKnockoutState;



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
        enemyBlockState = new EnemyBlockState(player, this);
        enemyHookState = new EnemyHookState(player, this);
        enemyHurtState = new EnemyHurtState(player,this);
        enemyJabState = new EnemyJabState(player, this);
        enemyNeutralState = new EnemyNeutralState(player, this);
        enemySpecialState = new EnemySpecialState();
        enemyKnockoutState = new EnemyKnockoutState(player, this);

    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        currentState = enemyNeutralState;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateManager(); // will maybe call if needed

                         // we will update according to the state
        if (GameManager.manager.EnemyPaused) // temporary, rewrite other states so they switch to neutral when they enter it and have the return in neutral state
        {
            currentState = enemyNeutralState;
            return;
        }


        currentState.UpdateState();






    }

    public void UpdateManager()
    {
        healthField.text = "Enemy Health: " + enemyHealth.ToString();
    }

    public void TakeDamage(float damage)
    {
        //GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        //counter = 0;
        enemyHealth -= damage;
    }

}
