using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPage : MonoBehaviour
{
    public GameObject startpage;
    public GameObject arrow;
    public GameObject fade;
    public bool black=false;
    public Color color;

    public AudioClip s1;
    public AudioClip s2;

    public Camera cam;
    //public Camera screenCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        startpage.SetActive(true);
        arrow.SetActive(false);
        color=fade.GetComponent<Image>().color;
        color.a = 0;

        AudioSource audiosource = cam.GetComponent<AudioSource>();
        audiosource.clip = s1;
        audiosource.Play();
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void GameStart()
    {
        cam.GetComponent<AudioSource>().clip = s2;
        cam.GetComponent<AudioSource>().Play();

        color.a++;
        if (color.a == 255.0f)
        {
            black = true;
        }

        if(black==true)
        {
            color.a--;
        }
        
        arrow.SetActive(true);
        startpage.SetActive(false);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    
    
}
