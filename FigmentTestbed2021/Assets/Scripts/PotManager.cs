using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PotManager : MonoBehaviour
{
    public ProgressBar potProgressBar;
    public float progressToAdd = 0.5f;
    public GameObject sugarWarning;
    public GameObject emptyPot;
    public GameObject fullPot;
    public GameObject burnPot;
    bool onStove;
    bool yesBean;
    bool yesSugar;
    bool makeEmpty;
    bool burnt;

    // Start is called before the first frame update
    void Start()
    {
        potProgressBar.gameObject.SetActive(false);
        sugarWarning.gameObject.SetActive(false);
        emptyPot.SetActive(true);
        fullPot.SetActive(false);
        burnPot.SetActive(false);
        

        this.gameObject.GetComponent<PickUpObject>();
        yesBean = false;
        yesSugar = false;
        makeEmpty = false;
        burnt = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (onStove && yesBean)
        {
            potProgressBar.gameObject.SetActive(true);
            IsBoiling();

        }

        if (yesBean && !yesSugar)
        {
            sugarWarning.SetActive(true);
        }

        if(!onStove)
        {
            potProgressBar.gameObject.SetActive(false);
            sugarWarning.SetActive(false);
        }

        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
        {
            if (makeEmpty)
            {
                emptyPot.SetActive(true);
                fullPot.SetActive(false);
                yesBean = false;
                yesSugar = false;
            }

            else if (!makeEmpty)
            {

            }
        }

        if (burnt == true)
        {
            emptyPot.SetActive(false);
            fullPot.SetActive(false);
            burnPot.SetActive(true);
            potProgressBar.gameObject.SetActive(false);
            sugarWarning.SetActive(false);
        }

        else if (burnt == false)
        {
            burnPot.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Sugar")
        {
            yesSugar = true;
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag=="Bean")
        {
            Debug.Log("BeanIn");
            yesBean = true;
            emptyPot.SetActive(false);
            fullPot.SetActive(true);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("PickUp"))
        {
            makeEmpty = true;
        }

        if (other.gameObject.CompareTag("Stove"))
        {
            onStove = true;
            Debug.Log("OnStove");
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Sugar")
        {
            yesSugar = false;
            
        }

        if(other.gameObject.tag=="Bean")
        {
            yesBean = false;
        }

        if (other.gameObject.CompareTag("Stove"))
        {
            onStove = false;
        }

    }

    public void IsBoiling()
    {
        potProgressBar.AddProgressToBar(progressToAdd);
        if (potProgressBar.barSlider.value >= potProgressBar.barSlider.maxValue)
        {
            
            burnt = true;
        }
    }

}

