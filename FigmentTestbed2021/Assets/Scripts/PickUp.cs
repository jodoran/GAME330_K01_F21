using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform myHand;
    bool canpickup; //a bool to see if you can or cant pick up the item
    bool hasItem; // a bool to see if you have an item in your hand

    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FigmentInput.GetButton(FigmentInput.FigmentButton.ActionButton))
        {
            hasItem = true;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = myHand.position;
            this.transform.parent = GameObject.Find("Player").transform;
        }

    }
}
