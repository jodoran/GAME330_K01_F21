using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float MoveUpSpeed = 1f;
    public Transform MoveUpTarget;
    //public Vector3 MoveUpVector;
    float scrollSpeed = 0.1f;
    Renderer rend;
    //public float MoveUpFloat = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 newPosition = MoveUpTarget.position + MoveUpVector;
        MoveUpSpeed = ((MoveUpSpeed + 0.00005f));
        transform.position = MoveUpTarget.position + ((new Vector3(0, MoveUpSpeed, 0)) * Time.deltaTime);
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));
    }
}
