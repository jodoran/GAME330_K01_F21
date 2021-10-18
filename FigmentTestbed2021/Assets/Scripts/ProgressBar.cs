using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Should be attached to the Progress Bar Slider Object
public class ProgressBar : MonoBehaviour
{
    public Slider barSlider;
    //Collider colliderr;
    public bool progressGoingUp;
    public float reductionSpeed = 1.0f;
    public float pauseTime = 1.0f;
    float timeUntilUnpause;
    public GameObject BackGround;
    public GameObject Slide;

    // Start is called before the first frame update
    void Start()
    {
        
        barSlider = GetComponent<Slider>();
        barSlider.value = 1;
        BackGround.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Slide.GetComponent<Image>().color = new Color32(125, 125, 125, 255);

    }

    // Update is called once per frame
    void Update()
    {
        if (!progressGoingUp)
        {
            ReduceSliderValueOverTime();
        }
        //Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        //transform.position = screenPos+new Vector3(2,0,0);
        //Ray ray = cam.ViewportPointToRay(target.position);
        //RaycastHit hit;
        //transform.position = (target.position);
    }

    public void AddProgressToBar(float progress)
    {
        barSlider.value += progress;
        progressGoingUp = true;
    }

    void ReduceSliderValueOverTime()
    {
        barSlider.value = Mathf.Max(0, barSlider.value - Time.deltaTime * reductionSpeed);
    }

    public void ChangeColor()
    {
        BackGround.GetComponent<Image>().color = new Color32(125,125,125, 255);
        Slide.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }

    public void ReStart()
    {
        barSlider.value = 0;
        BackGround.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Slide.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
    }
}
