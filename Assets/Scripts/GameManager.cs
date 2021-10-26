using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string textValue;
    public Text textElement;
    public Text ScoreText;
    public void GainPoint()
    {
        score1 = score1 + 1;
        ScoreText.text = "Score: " + score1;
        if(score1 > 3)
        {
            print("Victory");
        }
    }
    

    //score1 is player 1 : variable
    //Tiragon is player 2 : variable
    // 0: initial value assigned

    public static int score1 = 0;
    public static int lifeLeft = 5;

    public GUISkin myGUISkin;

    Transform theBall;

    public Transform lvl1;
    public Transform lvl2;
    public Transform lvl3;

    public Transform bg1;
    public Transform bg2;
    public Transform bg3;

    public static bool lvl2On = false;
    public static bool lvl3On = false;

    // Start is called before the first frame update
    void Start()
    {
       Instantiate(lvl1, GameObject.Find("GameRoot").transform);
       ScoreText.text = "Score" + score1;
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
