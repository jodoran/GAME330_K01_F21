using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathAndScore : MonoBehaviour
{
    public int score;
    public int highScore;
    //public Text ScoreColon;
    public Text RealScore;
    //public Text HighScoreColon;
    public Text RealHighScore;
    public float timer = 0.0f;
    public int seconds;
    public AudioClip death;
    AudioSource audioSource;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(death, 1.0f);
            score = 0;
            SceneManager.LoadScene(0);
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
        audioSource = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("highscore");
        RealHighScore.text = highScore.ToString();
        InvokeRepeating("increaseScore", (1.0f* Time.deltaTime), 1.0f);
    }

    void increaseScore()
    {
        score++;
    }

    // Update is called once per frame
    void Update()
    {

        RealScore.text = score.ToString();
        if (score > highScore)
        {
            highScore = score;
            RealHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }
}

//txt.text = yourNumberVariable.ToString()

// seconds in float
// timer += Time.deltaTime;
// turn seconds in float to int
// seconds = (int)(timer % 60);
//print(seconds);
// score = seconds;