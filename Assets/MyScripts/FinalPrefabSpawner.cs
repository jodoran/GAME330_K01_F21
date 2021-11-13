using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPrefabSpawner : MonoBehaviour
{
    //public GameObject spawnee;
    public float spawnTime;
    public float spawnDelay;
    public List<GameObject> prefabsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    public void SpawnObject()
    {
        int randomPrefab = Random.Range(0, prefabsToSpawn.Count);
        GameObject spawnee = prefabsToSpawn[randomPrefab];
        Instantiate(spawnee, transform.position, transform.rotation);
    }

}

/*
public bool stopSpawning = false;
if (stopSpawning == true)
{
    CancelInvoke("SpawnObject");
}*/
