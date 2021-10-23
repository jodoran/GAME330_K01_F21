using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainProgressBar : MonoBehaviour
{
    public Slider mainBarSlider;
    //Collider colliderr;
    public bool didFinish;
    public GameObject BackGround;
    public GameObject Slide;

    // Start is called before the first frame update
    void Start()
    {
        mainBarSlider = GetComponent<Slider>();
        mainBarSlider.value = 100;
        didFinish = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainBarProgress(float progress)
    {
        mainBarSlider.value -= progress;
        
    }
}
