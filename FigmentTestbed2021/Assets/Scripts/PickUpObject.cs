﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    public bool hasItem; // a bool to see if you have an item in your hand
    public AudioSource Blop;
    public int degree;

    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasItem == true)
        {
            canpickup = false;
        }

        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
        {
            if(hasItem == false)
            {
                if(canpickup == true)
                {
                    print("pick up");
                    hasItem = true;
                    GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                    transform.position = myHands.transform.position; // sets the position of the object to your hand position
                    transform.parent = GameObject.Find("Player").transform; //makes the object become a child of the parent so that it moves with the hands
                    Blop.Play();
                }
            }
            else if(hasItem ==true)
            {
                print("put down");
                hasItem = false;
                GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
                transform.parent = null; // make the object no be a child of the hands
                
                transform.position = myHands.transform.position + new Vector3(0, 1, -3);
                transform.rotation = Quaternion.Euler(degree, 0, 0);
            }

            
        }
        

    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Player") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
        }

        if(other.gameObject.tag=="Table"||other.gameObject.tag=="Stove")
        {
            if (hasItem == false)
            {
                transform.position = other.transform.position + new Vector3(0, 3.5f, 0);

            }

            else 
            {

            }
        }

        
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
       
    }
}
