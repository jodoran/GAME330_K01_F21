using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public GameObject TopPanel;
    public GameObject BottomPanel;

    private int score = 0;
    private int highScore = 0;
    //public Text ScoreColon;
    public Text RealScore;
    //public Text HighScoreColon;
    public Text RealHighScore;
    private float timer = 0.0f;
    private int seconds;
    public AudioClip death;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        


        //score = 0;
        audioSource = GetComponent<AudioSource>();
        highScore = PlayerPrefs.GetInt("highscore");
        RealHighScore.text = highScore.ToString();
        InvokeRepeating("increaseScore", (1.0f * Time.deltaTime), 1.0f);
    }

    void increaseScore()
    {
        score++;
    }

    void BackToStart()
    {
        SceneManager.LoadScene(0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Slime"))
        {
            audioSource.PlayOneShot(death, 1.0f);
            score = 0;
            TopPanel.SetActive(true);
            BottomPanel.SetActive(true);
            Invoke("BackToStart", 1f);
        }
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
