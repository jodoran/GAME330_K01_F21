using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceMaker : MonoBehaviour
{
    public ProgressBar iceProgressBar;
    public bool playerEnter;
    public bool ice;
    public float progressToAdd = 0.2f;
    public bool grinding;
    public GameObject DoneIce;
    // Start is called before the first frame update
    void Start()
    {
        iceProgressBar.gameObject.SetActive(false);
        grinding = false;

    }

    // Update is called once per frame
    void Update()
    {
        iceProgressBar.barSlider.value = 0;

        if (iceProgressBar.barSlider.value == iceProgressBar.barSlider.maxValue)
        {
            ice = true;
            grinding = false;
        }
        else if(iceProgressBar.barSlider.value ==0)
        {
            ice = false;
            //grinding = false;
        }
        else if (iceProgressBar.barSlider.value < iceProgressBar.barSlider.maxValue)
        {
            ice = false;
        }

        //else if (iceProgressBar.barSlider.value>0 && iceProgressBar.barSlider.value<iceProgressBar.barSlider.maxValue)
        //{
        //    grinding = true;
       // }
       
        if(grinding)
        {
            iceProgressBar.gameObject.SetActive(true);
            iceProgressBar.AddProgressToBar(progressToAdd);
            progressToAdd = 0.3f;
        }
       
    }

    public void Reset()
    {
        iceProgressBar.barSlider.value = 0;
        iceProgressBar.gameObject.SetActive(false);
        grinding = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ice == true)
            {
                
                if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
                {
                    Reset();
                }
            }

            else if (grinding)
            {
                
                if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
                {
                    
                }
            }

            else if (iceProgressBar.barSlider.value==0)
            {

            }
        }

        if (other.gameObject.CompareTag("Milk"))
        {

            if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
            {
                if (!grinding && !ice)
                {
                    
                    Destroy(other);
                    Instantiate(DoneIce, this.transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                    grinding = true;
                }

                else
                {

                }
            }
        }

        if(other.gameObject.CompareTag("Ice"))
        {
            if (ice == true)
            {
                other.GetComponent<PickUpObject>().enabled = true;
            }

            else
            {
                other.GetComponent<PickUpObject>().enabled = false;
            }
        }
    }


}


