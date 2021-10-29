using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brickbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.FindObjectOfType<GameManager>().GainPoint();
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
