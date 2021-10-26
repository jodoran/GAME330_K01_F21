using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public AudioClip explosion;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    void OnTriggerEnter2D(Collider2D other)

    {
        GameManager.score1 = GameManager.score1 + 1;
        audioSource.PlayOneShot(explosion, 0.7f);
        Invoke("destroyBrick", 0.2f);


    }
    
    void destroyBrick()
    {
        //destroy the brick
        Destroy(this.gameObject);
    }
}
