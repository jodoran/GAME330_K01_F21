using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject fireball;
    bool FireballFired = false;
    public AudioClip shoot;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FireballFired == false)
            {
                GameObject g = (GameObject)Instantiate(fireball, transform.position, Quaternion.identity);
                Physics.IgnoreCollision(g.GetComponent<BoxCollider>(), GetComponent<BoxCollider>());
                audioSource.PlayOneShot(shoot, 0.1f);
                FireballFired = true;
                Invoke("resetFireballFired", 0.2f);
            }
        }
    }
    void resetFireballFired()
    {
        FireballFired = false;
    }
}
