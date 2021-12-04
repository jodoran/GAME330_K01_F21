using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPage : MonoBehaviour
{
    public GameObject startpage;
    public GameObject arrow;
    public GameObject line;

    public GameObject Title;

    public AudioClip s1;
    public AudioClip s2;

    public Camera cam;
    //public Camera screenCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        MainPage();
        

        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void MainPage()
    {
        startpage.SetActive(true);
        arrow.SetActive(false);
        line.SetActive(false);
        Title.SetActive(true);

        cam.GetComponent<AudioSource>().clip = s1;
        cam.GetComponent<AudioSource>().Play();

    }

    public void GameStart()
    {
        cam.GetComponent<AudioSource>().clip = s2;
        cam.GetComponent<AudioSource>().Play();
        line.SetActive(true);
        Title.SetActive(false);



        arrow.SetActive(true);
        startpage.SetActive(false);
    }

    

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    
    
}
