using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationMark : MonoBehaviour
{
    public Transform Bike;
    public float height;
    public float rotationDamping = 3.0f;
    private Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //float wantedAngle = rotationVector.y;
        //float myAngle = transform.eulerAngles.y;
        //myAngle = Mathf.LerpAngle(myAngle, wantedAngle, rotationDamping * Time.deltaTime);
        float angleY = Bike.rotation.eulerAngles.y;

        //float myAngle = angleY;
        transform.rotation = Quaternion.Euler(90, angleY, 0);

        transform.position = Bike.position + new Vector3(0,height,0);
        //transform.LookAt(Bike);
    }

    void FixedUpdate()
    {
        //Vector3 localVelocity = Bike.InverseTransformDirection(Bike.GetComponent<Rigidbody>().velocity);

        //Vector3 temp = rotationVector;
        //temp.y = Bike.eulerAngles.y;
       // rotationVector = temp;

        
    }
}
