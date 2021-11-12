using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public MainProgressBar MainProgressBar;
    public bool gameIsDone=false;
    public float timespeed;
    public GameObject replayButton;
    public GameObject pot1;
    public GameObject pot2;
    public GameObject sugar;
    public GameObject emptybowl;
    public GameObject ice;
    public GameObject icebean;
    public GameObject icebeanricecake;
    public GameObject gameoverText;
    public bool allburnt;
    public int frame=5;
    public int burnpoint;

    public int modelNumber;

    // Start is called before the first frame update
    void Start()
    {
        modelNumber = 1;
        replayButton.SetActive(false);
        gameoverText.SetActive(false);
        //MainProgressBar.GetComponent<Slider>().value = timeLeft;
    }

    void ModelSwitch()
    {
        if(modelNumber == 1)
        {
            emptybowl.SetActive(false);
            ice.SetActive(true);
            modelNumber = 2;
        }
        else if (modelNumber == 2)
        {
            ice.SetActive(false);
            icebean.SetActive(true);
            modelNumber = 3;
        }
        else if (modelNumber == 3)
        {
            icebean.SetActive(false);
            icebeanricecake.SetActive(true);
            modelNumber = 4;
        }
        else if (modelNumber == 4)
        {
            icebeanricecake.SetActive(false);
            emptybowl.SetActive(true);
            modelNumber = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsDone == false)
        {
            MainProgressBar.MainBarProgress(timespeed);
        }
        else if (gameIsDone==true)
        {

        }

        if (MainProgressBar.mainBarSlider.value == 0)
        {
            DoneGame();
        }

        if (GameObject.FindGameObjectsWithTag("Sugar").Length == 0)
        {
            Instantiate(sugar, new Vector3(5000,4,3), Quaternion.identity);
        }

        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
        {
            ModelSwitch();
        }


        GameObject[] pots = GameObject.FindGameObjectsWithTag("Pot");
        foreach (GameObject go in pots)
        {
            //allburnt = true;
            if(burnpoint<2)
            {
                allburnt = false;
            }

            else if(burnpoint==2)
            {
                allburnt = true;
            }
        }

        if(allburnt==true && MainProgressBar.mainBarSlider.value <=98)
        {
            gameoverText.SetActive(true);
            
            DoneGame();
        }

    }


    /*public void GameOver()
    {
        gameoverText.SetActive(true);
        DoneGame();
    }*/

    public void DoneGame()
    {
        replayButton.SetActive(true);

        
        

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        //GameObject.FindWithTag("Pot").GetComponent<PickUpObject>().enabled = false;
        //GameObject.FindWithTag("Bowl").GetComponent<PickUpObject>().enabled = false;
        GameObject.FindWithTag("Sugar").GetComponent<PickUpObject>().enabled = false;

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Pot");
        foreach (GameObject go in foundObjects)
        {
            go.GetComponent<PickUpObject>().enabled = false;
            

            
            go.GetComponent<PotManager>().stop = true;
        }

        gameIsDone = true;

        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton) && gameIsDone)
        {
            Debug.Log("ClickRestart");
            //GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Pot");
            foreach (GameObject go in foundObjects)
            {

                //go.GetComponent<PotManager>().enabled = true;
                go.GetComponent<PotManager>().startAgain = true;
                go.GetComponent<PickUpObject>().enabled = true;
                
                //go.GetComponent<PotManager>().startAgain = false;

            }

            Replay();
            
        }
        //GameObject.FindWithTag("Pot").GetComponent<PotManager>().startAgain = true;



    }

    public void Replay()
    {
        gameoverText.SetActive(false);

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Pot");
        foreach (GameObject go in foundObjects)
        {
            StartCoroutine(Wait());
            go.GetComponent<PotManager>().stop = false;
            

        }

        gameIsDone = false;
        Debug.Log("Replay");
        replayButton.SetActive(false);
        MainProgressBar.mainBarSlider.value = 100;

        //GameObject.FindWithTag("Pot").GetComponent<PotManager>().startAgain = false;

        
        
        //Destroy(GameObject.FindWithTag("Pot"));

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        //GameObject.FindWithTag("Pot").GetComponent<PickUpObject>().enabled = true;
        //GameObject.FindWithTag("Bowl").GetComponent<PickUpObject>().enabled = true;
        GameObject.FindWithTag("Sugar").GetComponent<PickUpObject>().enabled = true;


        pot1.transform.position = new Vector3(5004, 4, 3);
        pot2.transform.position = new Vector3(5007, 4, 3);
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Pot");
        foreach (GameObject go in foundObjects)
        {
            

            go.GetComponent<PotManager>().startAgain = false;


        }
        
    }



}
