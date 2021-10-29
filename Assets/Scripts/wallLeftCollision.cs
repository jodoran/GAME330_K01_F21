using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallLeftCollision : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other)
    {

        // "wallLeft" game object = this.gameObject
        // game object that collides into "wallLeft" = other.gameObject

        //1 give one pt to the player 2

        //GameManager.lifeLeft = GameManager.lifeLeft + 1;

        //2 execute ResetBall() in ballMovement.cs
        other.gameObject.SendMessage("ResetBall");

        //3 left wall collision sound source
        audioSource.PlayOneShot(impact, 0.7F);
    }



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
