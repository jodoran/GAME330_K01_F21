using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject endPrefab;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI resultTimeText;
    public TextMeshProUGUI newRecordText;
    public TextMeshProUGUI highestRecordText;
    //private float time_start;
    private float currentTime;
    float shortestTime;
    //private float time_Max = 5f;
    public bool OnGame;
    public bool watchActive;
    public Camera TopCam;
    public Camera BottomCam;
    public GameObject pausePage;
    public GameObject Player;
    public GameObject EndPoint;
    private void Start()
    {
        endPrefab.SetActive(false);
        OnGame = false;
        pausePage.SetActive(false);
        Reset_Timer();
        resultTimeText.enabled = false;
        newRecordText.enabled = false;
        highestRecordText.enabled = false;
    }
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);

        if (OnGame == true)
        {
            currentTimeText.enabled = true;
            if (watchActive)
            {
                currentTime = currentTime + Time.deltaTime;

                currentTimeText.text = time.ToString(@"mm\:ss\:ff");
            }
        }

        else if (OnGame==false)
        {
            currentTimeText.enabled = false;
        }


        if (Input.GetButtonDown("Fire1")&&OnGame==true)
        {
            pausePage.SetActive(true);
            StopTimer();
        }

        if (shortestTime<currentTime)
        {

        }

        if(EndPoint.GetComponent<GameDone>().doneGame==true)
        {
            StopTimer();
            endPrefab.SetActive(true);
            OnGame = false;
            resultTimeText.enabled = true;
            resultTimeText.text = time.ToString(@"mm\:ss\:ff");
            if (PlayerPrefs.GetFloat("shortestTime")>currentTime||PlayerPrefs.GetFloat("shortestTime")==0)
            {
                PlayerPrefs.SetFloat("shortestTime", currentTime);
                newRecordText.enabled = true;


            }
            highestRecordText.enabled = true;
            //highestRecordText.text = "Highest Record:" + PlayerPrefs.GetFloat("shortestTime").ToString();
            highestRecordText.text = "Highest Record:" + TimeSpan.FromSeconds(PlayerPrefs.GetFloat("shortestTime")).ToString(@"mm\:ss\:ff");
        }
    }
    public void StartTimer()
    {
        watchActive = true;
    }

    public void StopTimer()
    {
        watchActive = false;
    }

    public void GameStart()
    {
        OnGame = true;

        TopCam.GetComponent<CameraController>().StartGame();
        BottomCam.GetComponent<CameraController>().StartGame();
    }

    public void MainPage()
    {
        Reset_Timer();
        pausePage.SetActive(false);
        currentTimeText.enabled = false;
        TopCam.GetComponent<CameraController>().StartPage();
        BottomCam.GetComponent<CameraController>().StartPage();
        OnGame = false;
        resultTimeText.enabled = false;
        newRecordText.enabled = false;
        highestRecordText.enabled = false;

        EndPoint.GetComponent<GameDone>().doneGame = false;
        EndPoint.GetComponent<GameDone>().endText.enabled = false;
        endPrefab.SetActive(false);
    }

    public void Resume()
    {
        pausePage.SetActive(false);
        StartTimer();
        

    }

    public void ReStart()
    {
        pausePage.SetActive(false);
        Reset_Timer();
        StartTimer();
        Player.GetComponent<BikeController>().StartButtonOn();
    }

    private void Reset_Timer()
    {
        //time_start = Time.time;
        currentTime = 0;
        
        Debug.Log("Start");
    }
}
