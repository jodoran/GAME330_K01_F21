using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float SpeedPerSecond = 2.0f;
    private GameObject ChasingTarget;
    public float DesiredDistanceFromTarget_Min = 3.5f;
    public float DesiredDistanceFromTarget_Max = 4.5f;
    bool hit = false;
    private SpriteRenderer SR;

    // Start is called before the first frame update
    void Start()
    {
        ChasingTarget = GameObject.Find("PlayerCharacter");
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredDirection = new Vector3();
        Vector3 vectorToTarget = ChasingTarget.transform.position - transform.position;
        float distanceToTarget = vectorToTarget.magnitude;
        desiredDirection = vectorToTarget;
        if (desiredDirection.x < 0)
        {
            SR.flipX = false;
        }
        else
        {
            SR.flipX = true;
        }
        desiredDirection.Normalize();
        if (hit == false)
        {
            transform.position += desiredDirection * SpeedPerSecond * Time.deltaTime;
        }
    }

    void ChangeHit()
    {
        hit = false;
        SR.color = Color.white;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "PlayerCharacter")
        {
            Destroy(gameObject);
        }
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            hit = true;
            Invoke("ChangeHit", 1f);
            SR.color = Color.red;
        }
    }

}
