using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDone : MonoBehaviour
{
    public Text endText;
    
    public GameManager gamemanager;
    public bool doneGame;
    //attach this to the finishpoint
    // Start is called before the first frame update
    void Start()
    {
        doneGame = false;
        endText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            GameIsDone();
        }
    }

    public void GameIsDone()
    {
        doneGame = true;
        endText.enabled = true;
        
    }
}
