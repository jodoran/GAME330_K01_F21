using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnHit : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains ("Explosion"))
        {
            Destroy(gameObject);
        }

    }


}
