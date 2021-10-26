using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Right,Left fx
    public KeyCode moveRight = KeyCode.RightArrow;
    public KeyCode moveLeft = KeyCode.LeftArrow;



    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(moveRight))
        {
            var vel = GetComponent<Rigidbody2D> ().velocity;
            vel.x = speed;
            GetComponent<Rigidbody2D> ().velocity = vel;

        } else if (Input.GetKeyDown(moveLeft))
        {
            var vel = GetComponent<Rigidbody2D> ().velocity;
            vel.x = -1.0f*speed;
            GetComponent<Rigidbody2D> ().velocity = vel;
            
        } else if (!Input.anyKey)
        {
            var vel = GetComponent<Rigidbody2D> ().velocity;
            vel.x = 0.0f;
            GetComponent<Rigidbody2D> ().velocity = vel;

        }

    }
}
