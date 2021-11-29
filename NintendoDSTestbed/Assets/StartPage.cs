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
    //public Camera screenCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        startpage.SetActive(true);
        arrow.SetActive(false);
        color=fade.GetComponent<Image>().color;
        color.a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void GameStart()
    {

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

    
    
}
