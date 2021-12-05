using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public GameObject Explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnExplosion", 2.1f);
    }

    // Update is called once per frame
    void SpawnExplosion()
    {
        GameObject g = Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(g, 0.7f);
    }
}
