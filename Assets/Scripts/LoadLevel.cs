using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    public string levelToLoad; // name of the scene we want to open

    public bool cleared;

    // Start is called before the first frame update
    void Start()
    {
        // When we open Map Scene, we check does GameManager mark this as passed
        // if it is passed then we run cleared function with parameter true. That will will display
        // level cleared image and remove collider.



        if (GameManager.manager.GetType().GetField(levelToLoad).
            GetValue(GameManager.manager).ToString() == "True")
        {
            Cleared(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cleared(bool IsClearn)
    {
        if(IsClearn == true)
        {
            cleared = true;
            // we set correct boolean variable true in Game Manager
            GameManager.manager.GetType().GetField(levelToLoad).SetValue(GameManager.manager, true);

            // Display Level clear sign
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            // Becouse level is passed, we want to disable collider, so we don't end up back to
            // already passed level
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
