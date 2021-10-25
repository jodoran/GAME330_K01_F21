using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bowl")
        {
            print("Score");
            ScoreText.scoreValue += 10;
            Destroy(col.gameObject);
        }
    }
}
