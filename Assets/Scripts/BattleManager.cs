using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{

    public static BattleManager battleManager;

    public bool PlayerPaused = false;
    public bool EnemyPaused = false;


    public TMP_Text RoundField;
    public TMP_Text TimerField;
    public TMP_Text KnockOutTimerTextField;

    public bool InBattle;


    //public string currentLevel;
    public float FightTimer = 0;
    public float score = 0;
    public int round = 1;





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
        RoundField.text = "Round: 1";
    }

    void MatchTimer()
    {
        FightTimer += Time.deltaTime;

        TimerField.text = "Time: " + Math.Floor(FightTimer).ToString();



        if (FightTimer >= 180)
        {
            FightTimer = 0;
            round += 1;
            RoundField.text = "Round: " + round.ToString();
            // next round, insert function here
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InBattle)
        {
            if (!PlayerPaused || !EnemyPaused)
                MatchTimer();



        }


        if (Input.GetKeyUp(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
