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
       
        if(grinding==true)
        {
            iceProgressBar.gameObject.SetActive(true);
            Grinding();
            progressToAdd = 1.0f;

            DoneIce.GetComponent<PickUpObject>().enabled = false;
            Debug.Log("Grinding");
        }

        else if(grinding==false)
        {
            progressToAdd = 0.0f;
            iceProgressBar.progressGoingUp = false;
            //Debug.Log("GrindingFalse");
        }
       
    }

    public void Grinding()
    {
        iceProgressBar.AddProgressToBar(progressToAdd);

    }

    void Reset()
    {
        iceProgressBar.barSlider.value = 0;
        iceProgressBar.gameObject.SetActive(false);
        grinding = false;
        Debug.Log("IceReset");
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
                    Debug.Log("No ice");
                }
            }
            else if(ice==false)
            {

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

            
                if (!grinding && !ice )
                {
                    
                    Destroy(other);
                    Instantiate(DoneIce, new Vector3(5006, 2.8f, -4.7f), Quaternion.identity);
                    grinding = true;
                    Debug.Log("Grind");
                }

                else
                {

                }
            
        }

        if(other.gameObject.CompareTag("Bowl")|| other.gameObject.CompareTag("Ice"))
        {
            if (ice == true)
            {
                other.GetComponent<PickUpObject>().canpickup = true;
            }

            else
            {
                other.GetComponent<PickUpObject>().canpickup = false;
            }
        }
    }


}


