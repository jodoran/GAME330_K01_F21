using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public float MovementSpeed;
    private Vector3 MovementInput;
    AudioSource move_audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        move_audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
        Animate();
    }

    private void Move()
    {
        
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");
        if (Horizontal == 0 && Vertical == 0)
        {
            move_audioSource.Play();
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }
        MovementInput = new Vector3(Horizontal, Vertical, 0);
        rb.velocity = MovementInput * MovementSpeed * Time.fixedDeltaTime;
    }

    private void Animate()
    {
        if(rb.velocity.magnitude <= 0.1f)
        {
            //Get Animator state after storing the Animator reference in my var 'animate'.

            var currentState = anim.GetCurrentAnimatorStateInfo(0);

            var stateName = currentState.nameHash;



            //Then later I can call...



            //Reset Animation on first frame.

            anim.Play(stateName, 0, 0.0f);

            anim.speed = 0;
        }
        else
        {
            anim.speed = 1;
        }
        anim.SetFloat("MovementX", MovementInput.x);
        anim.SetFloat("MovementY", MovementInput.y);
    }

}
