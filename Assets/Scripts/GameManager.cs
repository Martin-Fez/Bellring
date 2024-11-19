using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;

    public string currentLevel;
    public float health;// current health left
    public float previousHealth; // before we took damage
    public float maxHealth; // max hp

    public bool Level1;
    public bool Level2;
    public bool Level3;

    private void Awake()
    {
        // Singleton
        // We want to make sure we have only one instance of GameManger in our game
        if(manager == null)
        {
            // if we do not have a manager let's tell that this class instance is the manager
            // we also tell that this manager cannot be destroyed if we cahnce the scene
            DontDestroyOnLoad(gameObject);
            manager = this;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();
        // copy information from Game Manager to Player data
        data.health = health;
        data.previousHealth = previousHealth;
        data.maxHealth = maxHealth;
        data.Level1 = Level1;
        data.Level2 = Level2;
        data.Level3 = Level3;
        bf.Serialize(file, data);
        file.Close();



    }

    public void Load()
    {
        // We check if there is a saved file in the folder in the persistent folder
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            // we continue with loading
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // Move the information to Game Manager
            health = data.health;
            previousHealth = data.previousHealth;
            maxHealth = data.maxHealth;
            Level1 = data.Level1;
            Level2 = data.Level2;
            Level3 = data.Level3;
        }
    }
}

[Serializable]

class PlayerData
{
    public string currentLevel;
    public float health;// current health left
    public float previousHealth; // before we took damage
    public float maxHealth; // max hp

    public bool Level1;
    public bool Level2;
    public bool Level3;
}

// Another class that we can serialize. This cointain only
