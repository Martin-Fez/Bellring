using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public bool autoLoad = true;
    // Start is called before the first frame update
    void Start()
    {
        if(autoLoad)
            SceneManager.LoadScene("MainMenu");


    }

    void Update()
    {
        if (Input.GetKey("space"))
            SceneManager.LoadScene("MainMenu");
    }


}
