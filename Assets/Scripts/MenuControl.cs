using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Start is called before the first frame update

    public void LoadMap()
    {
        // we want to run this function when player press play button in the main menu
        SceneManager.LoadScene("Level1");
    }


    public void Continue()
    {
        GameManager.manager.Load();
        if (GameManager.manager.lastLevelCleared > 2)
            return;

        SceneManager.LoadScene("Level" + (GameManager.manager.lastLevelCleared+1).ToString());


    }

    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }

}
