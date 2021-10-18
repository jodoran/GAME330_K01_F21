using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    bool generate;
    public Object Ingredient;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ingredient, this.transform.position+ new Vector3(0, -0.5f, 0), Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
        {
            if(generate==true)
            {
                Instantiate(Ingredient, this.transform.position + new Vector3(0, -0.5f, 0), Quaternion.identity);
            }

            else if(generate==false)
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            generate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
            generate = false;
        
    }
}
