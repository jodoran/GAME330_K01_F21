using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    public Animator animator;
    float horizontalMove = 0f;
    public bool isGrounded;
    public Transform GroundCheckPoint;
    public Transform WallGrabPoint;
    public float WallJumpTime = 0.8f;
    private float WallJumpCounter;
    private float GripSlide = 0f;
    public LayerMask whatisGround;
    private bool canGrab, isGrabbing;

    public AudioClip jump;
    public AudioClip walljump;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WallJumpCounter <= 0)
        {
            theRB.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y, 0);

            horizontalMove = theRB.velocity.x;

            //isGrounded = Physics.OverlapSphere(GroundCheckPoint.position, .2f, whatisGround);

            if (Physics.OverlapSphere(GroundCheckPoint.position, .2f, whatisGround).Length > 0)
            {
                isGrounded = true;
                animator.SetBool("IsJumping", false);
            }
            else
            {
                isGrounded = false;
            }

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump") && isGrounded == true)
            {
                animator.SetBool("IsJumping", true);
                audioSource.PlayOneShot(jump, 0.7f);
                theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, 0);
            }

            //flip direction
            if (theRB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1, 1f);
            }

            isGrabbing = false;

            canGrab = Physics.OverlapSphere(WallGrabPoint.position, .2f, whatisGround).Length > 0;

            if (canGrab && !isGrounded)
            {
                isGrabbing = true;
                animator.SetBool("IsGrabbing", true);
            }

            if (isGrabbing)
            {
                theRB.useGravity = false;
                GripSlide = GripSlide - 0.001f;
                theRB.velocity = new Vector3(0, GripSlide, 0);
                if (Input.GetButtonDown("Jump"))
                {
                    animator.SetBool("IsJumping", true);
                    audioSource.PlayOneShot(walljump, 0.7f);
                    WallJumpCounter = WallJumpTime;
                    theRB.velocity = new Vector3(-transform.localScale.x * moveSpeed, jumpForce, 0);
                    theRB.useGravity = true;
                    isGrabbing = false;
                    if (theRB.velocity.x > 0)
                    {
                        transform.localScale = Vector3.one;
                    }
                    else if (theRB.velocity.x < 0)
                    {
                        transform.localScale = new Vector3(-1f, 1, 1f);
                    }
                }
            }
            else
            {
                GripSlide = 0f;
                theRB.useGravity = true;
                animator.SetBool("IsGrabbing", false);
            }

        }
        else
        {
            WallJumpCounter -= Time.deltaTime;
        }
    }
}

// && Input.GetAxisRaw("Horizontal") > 0
// && Input.GetAxisRaw("Horizontal") < 0
// -Input.GetAxisRaw("Horizontal")
// if((transform.localScale.x == 1f) || (transform.localScale.x == -1f))

