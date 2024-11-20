using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using UnityEngine.UI;
using TMPro;

public class StatePatternPlayer : MonoBehaviour
{
    public MeshRenderer indicator1;
    public MeshRenderer indicator2;
    public MeshRenderer indicator3;

    public int hearts = 30; // if this hits 0, player becomes tired

    public Image filler; // this is the image. we\ll adjust fillamount value

    //public string playerName;

    public TMP_Text healthField;
    //public TMP_Text nameField;


    //[HideInInspector] public Transform chaseTarget; // This is what we chase in chase state. Usually Player.
    [HideInInspector] public IPlayerState currentState;
    [HideInInspector] public DuckState duckState;
    [HideInInspector] public NeutralState neutralState;
    [HideInInspector] public BlockState blockState;
    [HideInInspector] public LeftDodgeState leftDodgeState;
    [HideInInspector] public RightDodgeState rightDodgeState;
    [HideInInspector] public RJabState rJabState;
    [HideInInspector] public LJabState lJabState;
    [HideInInspector] public RUpJabState rUpjabState;
    [HideInInspector] public LUpJabState lUpJabState;
    [HideInInspector] public UpperCutState upperCutState;
    [HideInInspector] public HurtState hurtState;


    private void Awake()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();

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
        // maybe add a state where player is hit


    //trackingState = new TrackingState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Let's tell enemy that in the beginning it's current state is the patrolStaet
        currentState = neutralState;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateManager();
        // we will update according to the state
        currentState.UpdateState();






    }

    public void UpdateManager()
    {
        healthField.text = GameManager.manager.health.ToString();
    }


    /*
    public void TakeDamage(float damage)
    {
        GameManager.manager.previousHealth = filler.fillAmount * GameManager.manager.maxHealth;
        counter = 0;
        GameManager.manager.health -= damage;
    }
    */

}
