using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public float number;

    

    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }

    void Update()
    {
        if (thePlayer.transform.position == teleportTarget.position)
        {
            thePlayer.transform.rotation = Quaternion.Euler(0, 90, 0);
            thePlayer.transform.position = thePlayer.transform.position+ Vector3.right*number;
            
        }
    }
}

