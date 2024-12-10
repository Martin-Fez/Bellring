using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public static BattleManager battleManager;

    public StatePatternPlayer player;
    public StatePatternEnemyBoxer enemyBoxer; 


    public bool PlayerPaused;
    public bool EnemyPaused;


    public TMP_Text RoundField;
    public TMP_Text TimerField;
    public TMP_Text KnockOutTimerTextField;

    public GameObject UIPanel;

    public bool InBattle = false;


    //public string currentLevel;
    public float FightTimer = 0;
    public float score = 0;
    public int round = 1;
    float PauseTimer = 0;

    public bool ResumeMatch = false;
    bool BeginMatch = true;
    bool Intermission = false;



    public int restoreHP;
    public int restoreEnemyHP;



    private void Awake()
    {
        // Singleton
        // We want to make sure we have only one instance of GameManger in our game
        if (battleManager == null)
        {
            // if we do not have a manager let's tell that this class instance is the manager
            // we also tell that this manager cannot be destroyed if we cahnce the scene
            DontDestroyOnLoad(gameObject);
            battleManager = this;
        }
        else
        {
            //we will run this if there already is a manager in the scene for some reason
            // then this manger will be a second manager and that is not allowed. We'll destroy the second "king" in this game
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //BeginMatch = true;
        //PlayerPaused = true;
        //EnemyPaused = true;

        //startMatch();
        RoundField.text = "Round: 1";
    }

    void MatchTimer()
    {
        FightTimer += Time.deltaTime;

        float minutes = Mathf.FloorToInt(FightTimer / 60);
        float seconds = Mathf.FloorToInt(FightTimer % 60);

        //if(FightTimer < 60f)
        //  TimerField.text = "Time: " + seconds;
        //else
        //  TimerField.text = "Time: " + minutes.ToString() + ":" + seconds.ToString();

        //string timeTEXT = string.Format("{0,00):{1,00}",minutes,seconds);

        //TimerField.text = "Time: " + timeTEXT;
        TimerField.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);


        //TimerField.text = "Time: " + Math.Floor(FightTimer).ToString();

        if (FightTimer >= 180)
        {


            FightTimer = 0;
            round += 1;
            RoundField.text = "Round: " + round.ToString();

                //


            InBattle = false;
            PlayerPaused = true;
            EnemyPaused = true; 


            if(round > 3)
                DetermineWinner();
            else
            {
                Intermission = true;
                UIPanel.SetActive(true);
                KnockOutTimerTextField.text = "INTERMISSION\nPress spacebar to start the next round";

                // Restore enemy hp here

            }
            // 
            // next round, insert function here
        }

    }

    void PauseResume()
    {
        PauseTimer += Time.deltaTime;

        UIPanel.SetActive(true);
        KnockOutTimerTextField.text = "Resuming fight in:\n" + (3f - Math.Floor(PauseTimer)).ToString();

        if (PauseTimer > 3f)
            KnockOutTimerTextField.text = "GO";

        if (PauseTimer > 4f)
        {

            PauseTimer = 0;
            KnockOutTimerTextField.text = "";
            InBattle = true;
            ResumeMatch = false;
            PlayerPaused = false;
            EnemyPaused = false;
            UIPanel.SetActive(false);

        }


    }


    void startMatch()
    {
        PauseTimer += Time.deltaTime;

        UIPanel.SetActive(true);
        KnockOutTimerTextField.text = "starting fight in:\n" + (3f - Math.Floor(PauseTimer)).ToString();

        //Debug.Log((5f - Math.Floor(PauseTimer)).ToString() +  " and " + PauseTimer.ToString() );

        if(PauseTimer > 3f)
            KnockOutTimerTextField.text = "GO";


        if (PauseTimer > 4f)
        {

            PauseTimer = 0;
            KnockOutTimerTextField.text = "";
            InBattle = true;
            PlayerPaused = false;
            EnemyPaused = false;
            BeginMatch = false;
            UIPanel.SetActive(false);

        }
    }

    void RoundIntermission()
    {
        if(Input.GetKey("space"))
        {
            
            Intermission = false;
            ResumeMatch = true;
            enemyBoxer.enemyHealth += (enemyBoxer.enemyMaxHealth / 5) * (3 - enemyBoxer.enemyKnockoutsThisRound);
            if(enemyBoxer.enemyHealth > enemyBoxer.enemyMaxHealth)
                enemyBoxer.enemyHealth = enemyBoxer.enemyMaxHealth;
            enemyBoxer.enemyKnockoutsThisRound = 0;

            player.health += (player.maxHealth / 5) * (3 - player.knockoutsThisRound);
            if(player.health > player.maxHealth)
                player.health = player.maxHealth;
            player.knockoutsThisRound = 0;

        }
    }

    void DetermineWinner()
    {
        if (player.knockoutsTotal > enemyBoxer.enemyKnockoutsThisRound || 
            (player.knockoutsTotal == enemyBoxer.enemyKnockoutsThisRound && player.health > enemyBoxer.enemyHealth))
        {
            UIPanel.SetActive(true);
            KnockOutTimerTextField.text = "PLAYER WINS";
            return;

        }

        if (player.knockoutsTotal < enemyBoxer.enemyKnockoutsThisRound ||
            (player.knockoutsTotal == enemyBoxer.enemyKnockoutsThisRound && player.health < enemyBoxer.enemyHealth))
        {
            UIPanel.SetActive(true);
            KnockOutTimerTextField.text = "ENEMY WINS";
            return;
        }

        UIPanel.SetActive(true);
        KnockOutTimerTextField.text = "TIE";



    }

    // Update is called once per frame
    void Update()
    {

        if (InBattle)
        {
            if (!PlayerPaused && !EnemyPaused)
                MatchTimer();



        }

        if(ResumeMatch)
            PauseResume();

        if (BeginMatch)
            startMatch();

        if(Intermission)
            RoundIntermission();

    }
}


