using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp2 : MonoBehaviour
{
    public Transform MoveUpTarget;
    public float MoveUpSpeed = 1f;
    //public Vector3 MoveUpVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = MoveUpTarget.position + ((new Vector3(0, MoveUpSpeed, 0)) * Time.deltaTime);
    }
}
