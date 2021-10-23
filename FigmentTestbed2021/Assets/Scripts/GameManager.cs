using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public MainProgressBar MainProgressBar;
    bool gameIsDone=false;
    public float timespeed;
    public GameObject replayButton;
    public GameObject pot1;
    public GameObject pot2;
    public GameObject sugar;
    // Start is called before the first frame update
    void Start()
    {
        
        replayButton.SetActive(false);
        //MainProgressBar.GetComponent<Slider>().value = timeLeft;
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

    }

    public void DoneGame()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.FindWithTag("Pot").GetComponent<PickUpObject>().enabled = false;
        //GameObject.FindWithTag("Bowl").GetComponent<PickUpObject>().enabled = false;
        GameObject.FindWithTag("Sugar").GetComponent<PickUpObject>().enabled = false;

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Pot");
        foreach (GameObject go in foundObjects)
        {
            go.GetComponent<PotManager>().startAgain = true;
        }


        //GameObject.FindWithTag("Pot").GetComponent<PotManager>().startAgain = true;
        replayButton.SetActive(true);
        gameIsDone = true;
        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton)&& gameIsDone)
        {
            Replay();
        }
        
        
    }

    public void Replay()
    {
        gameIsDone = false;
        Debug.Log("Replay");
        replayButton.SetActive(false);
        MainProgressBar.mainBarSlider.value = 100;

        //GameObject.FindWithTag("Pot").GetComponent<PotManager>().startAgain = false;

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("Pot");
        foreach (GameObject go in foundObjects)
        {
            //Destroy(go);
            go.GetComponent<PotManager>().startAgain = false;
        }
        
        //Destroy(GameObject.FindWithTag("Pot"));

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.FindWithTag("Pot").GetComponent<PickUpObject>().enabled = true;
        //GameObject.FindWithTag("Bowl").GetComponent<PickUpObject>().enabled = true;
        GameObject.FindWithTag("Sugar").GetComponent<PickUpObject>().enabled = true;


        pot1.transform.position = new Vector3(5004, 4, 3);
        pot2.transform.position = new Vector3(5007, 4, 3);
        //Instantiate(pot1,new Vector3(5004, 4, 3), Quaternion.identity);
        //Instantiate(pot2, new Vector3(5007, 4, 3), Quaternion.identity);
    }
}
