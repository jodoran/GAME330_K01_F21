using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowlScript : MonoBehaviour
{
    
    //public GameObject pot1;
    //public GameObject pot2;
    
    public GameObject emptybowl;
    public GameObject ice;
    public GameObject icebean;
    public GameObject icebeanricecake;
    

    private int modelNumber;

    // Start is called before the first frame update
    void Start()
    {
        modelNumber = 1;
        ice.SetActive(false);
        icebean.SetActive(false);
        icebeanricecake.SetActive(false);
        emptybowl.SetActive(true);
    }
    void ModelSwitch()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (GetComponent<PickUpObject>().hasItem == false)
        {
            
            if (modelNumber == 1 && other.CompareTag("IceMaker"))
            {

                emptybowl.SetActive(false);
                ice.SetActive(true);
                modelNumber = 2;
            }
            else if (modelNumber == 2 && other.CompareTag("Pot") && other.gameObject.GetComponent<PotManager>().done==true && other.gameObject.GetComponent<PotManager>().burnt == false)
            {
                ice.SetActive(false);
                icebean.SetActive(true);
                modelNumber = 3;
            }
            else if (modelNumber == 3 && other.CompareTag("RiceCake"))
            {
                icebean.SetActive(false);
                icebeanricecake.SetActive(true);
                modelNumber = 4;
            }
            else if (modelNumber == 4 &&other.CompareTag("PickUp"))
            {
                icebeanricecake.SetActive(false);
                emptybowl.SetActive(true);
                modelNumber = 1;
                Instantiate(icebeanricecake, other.transform.position, Quaternion.identity);
            }
            else 
            {
            
            }
        }
       
        else if(GetComponent<PickUpObject>().hasItem == true)
        {

        }
        
    }
}
