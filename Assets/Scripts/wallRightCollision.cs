using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRightCollision : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other)
    {

        // "wallRight" game object = this.gameObject
        // game object that collides into "wallLeft" = ball.gameObject

        //1 give one pt to the player 1
        GameManager.score1 = GameManager.score1 + 1;

        //2 reposition the ball to the center

        other.gameObject.SendMessage("ResetBall");


        //3 right wall collision sound source
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
