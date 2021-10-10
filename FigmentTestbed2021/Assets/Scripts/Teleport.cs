using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }

    void Update()
    {
        if (thePlayer.transform.position == teleportTarget.position)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
