using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour

{
    public float speed = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        goBall();

    }
    void goBall()
    {
        //1. Generate a random number between -1.0f and 1.0f
        float rand = Random.Range(-1.0f, 1.0f);

        if (rand <= 0.0f)
        {
            // if a negative number generated, Push the ball to the left
            GetComponent<Rigidbody>().AddForce(new Vector3(150.0f, 0f, 150.0f));

        }
        else
        {
            // if a positive number generated, Push the ball to the right
            GetComponent<Rigidbody>().AddForce(new Vector3(-150.0f, 0f, 150.0f));

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        var vel = GetComponent<Rigidbody>().velocity;
        var rb = GetComponent<Rigidbody>();
        rb.velocity = rb.velocity.normalized * speed;
    }
    void ResetBall()
    {
        var vel = GetComponent<Rigidbody>().velocity;
        vel.x = 0.0f;
        vel.y = 0.0f;
        GetComponent<Rigidbody>().velocity = vel;

        transform.position = new Vector3(5000.0f, 2.59f, -3.46f);

        goBall();

    }

    void hasWon()
    {
        //1 reposition the ball to the center
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        //2 stop the ball
        var vel = GetComponent<Rigidbody>().velocity;
        vel.x = 0.0f;
        vel.y = 0.0f;
        GetComponent<Rigidbody>().velocity = vel;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
