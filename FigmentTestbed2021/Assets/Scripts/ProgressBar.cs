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
    // Start is called before the first frame update
    void Start()
    {
        barSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!progressGoingUp)
        {
            ReduceSliderValueOverTime();
        }
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
}
