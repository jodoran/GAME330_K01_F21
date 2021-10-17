using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public Vector3 teleportOffset;

    void OnTriggerEnter(Collider other)
    {
        // If it's the player or an object that the player isn't holding
        if (other.CompareTag("Player"))
        {
            print("Teleport");
            other.transform.position = teleportTarget.transform.position + teleportOffset;
        }
        
    }

}

