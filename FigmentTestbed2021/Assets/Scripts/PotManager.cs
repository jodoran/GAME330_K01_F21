using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PotManager : MonoBehaviour
{
    //public Transform Pot;

    public ProgressBar potProgressBar;
    public ProgressBar bar1;
    public ProgressBar bar2;
    public float progressToAdd = 0.1f;
    public GameObject sugarWarning;
    public GameObject sw1;
    public GameObject sw2;
    public GameObject emptyPot;
    public GameObject fullPot;
    public GameObject burnPot;
    public GameManager GameManager;
    //public int burnpoint;
    bool onStove;
    bool yesBean;
    bool yesSugar;
    bool makeEmpty;
    public bool burnt;
    //public bool destroyThis=false;
    public bool startAgain = false;
    public bool done;
    bool speedUp;
    bool addburnp=true;
    public bool stop=false;


    // Start is called before the first frame update
    void Start()
    {
        //bar1 = ProgressBar.FindObjectOfType<ProgressBar>();

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
        done = false;
        speedUp = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(startAgain==true)
        {
            ReStart();
        }
        
        /*if(destroyThis==true)
        {
            Destroy(this.gameObject);
        }*/

        if (done == false)
        {
            GetComponent<PickUpObject>().canpickup = false;

        }
        else if (done == true)
        {

        }

        if (onStove && yesBean)
        {

            potProgressBar.gameObject.SetActive(true);
            IsBoiling();

        }

        if (yesBean && !yesSugar)
        {
            sugarWarning.SetActive(true);
        }

        if (!onStove || GetComponent<PickUpObject>().hasItem == true)
        {
            potProgressBar.progressGoingUp = false;
            potProgressBar.gameObject.SetActive(false);
            sugarWarning.SetActive(false);

        }

        if (yesSugar)
        {
            sugarWarning.SetActive(false);
        }

        
        if(stop==false)
        {
            if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
            {
                if (makeEmpty)
                {
                    emptyPot.SetActive(true);
                    fullPot.SetActive(false);
                    burnPot.SetActive(false);
                    yesBean = false;
                    yesSugar = false;
                    potProgressBar.ReStart();
                }

                else if (!makeEmpty)
                {

                }

                if (speedUp == true)
                {
                    progressToAdd = 0.3f;
                }

                else if (!speedUp)
                {
                    progressToAdd = 0.1f;
                }
            }

            if (FigmentInput.GetButtonUp(FigmentInput.FigmentButton.ActionButton))
            {
                progressToAdd = 0.1f;
            }

        }

        else if(stop==true)
        {

        }
        

        if (burnt == true)
        {
            emptyPot.SetActive(false);
            fullPot.SetActive(false);
            burnPot.SetActive(true);
            potProgressBar.gameObject.SetActive(false);
            sugarWarning.SetActive(false);

            //PickUpObject PUO = GetComponent<PickUpObject>();
            //PUO.enabled = false;
        }

        else if (burnt == false)
        {
            burnPot.SetActive(false);

           // PickUpObject PUO = GetComponent<PickUpObject>();
            //PUO.enabled = true;
        }

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sugar")
        {
            yesSugar = true;
            Destroy(other.gameObject);
        }

        

        if (other.gameObject.tag == "Bean")
        {
            Debug.Log("BeanIn");
            yesBean = true;
            emptyPot.SetActive(false);
            fullPot.SetActive(true);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("Bowl"))
        {
            if (burnt == false)
            {
                makeEmpty = true;
            }

            else if (burnt == true)
            {
                makeEmpty = false;
            }
        }

        if (other.gameObject.CompareTag("Stove"))
        {
            if (GetComponent<PickUpObject>().hasItem == false)
            {
                onStove = true;
                Debug.Log("OnStove");

                if (other.gameObject.name == "Stove1")
                {
                    potProgressBar = bar1;
                    sugarWarning = sw1;
                }

                else if (other.gameObject.name == "Stove2")
                {
                    potProgressBar = bar2;
                    sugarWarning = sw2;
                }
            }

            else if (GetComponent<PickUpObject>().hasItem == false)
            {

            }

        }

        if (other.gameObject.CompareTag("Player"))
        {
            speedUp = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Stove"))
        {
            onStove = false;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            speedUp = false;
        }

    }

    public void IsBoiling()
    {
        potProgressBar.AddProgressToBar(progressToAdd);
        if (potProgressBar.barSlider.value >= potProgressBar.barSlider.maxValue)
        {
            if (done == false)
            {
                potProgressBar.barSlider.value = 0;

                potProgressBar.ChangeColor();
                progressToAdd = 0.3f;
                done = true;
            }

            else if (done == true)
            {
                burnt = true;

                potProgressBar.gameObject.SetActive(false);

                if (addburnp==true)
                {
                    GameManager.burnpoint++;
                    addburnp = false;
                }

                else if(!addburnp)
                {

                }
                
                
            }

        }
    }

    public void ReStart()
    {
        done = false;
        burnt = false;
        potProgressBar.gameObject.SetActive(false);
        sugarWarning.gameObject.SetActive(false);
        emptyPot.SetActive(true);
        fullPot.SetActive(false);
        burnPot.SetActive(false);
        yesBean = false;
        yesSugar = false;
        
        potProgressBar.ReStart();

        addburnp = true;
        GameManager.burnpoint = 0;

        //Debug.Log("RestartPot");

    }


}

