using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //public int SpawnCount = 10;
    //private GameObject EnemyToSpawn;
    //private bool SpawnYes = false;

    public float SpawnCooldownSeconds = 0.0f;
    public Transform player;
    public Transform minPos;
    public Transform maxPos;
    public Vector3 newPos = Vector3.zero;
    public GameObject enemyObject;
    float minDistance = 10;
    //public float lala = 0;
    

    void Start()
    {

        newPos.z = 35.8f;
    }
    Vector3 GetRandomSpawnPos()
    {
        //Vector3 newPos = Vector3.zero;

        newPos.x = UnityEngine.Random.Range(minPos.position.x, maxPos.position.x);
        newPos.y = UnityEngine.Random.Range(minPos.position.y, maxPos.position.y);
        

        // Check if the point is too close to the player
        if (Vector3.Distance(transform.position, player.position) < minDistance)
        {
            // If the point is not good; find a new one
            return GetRandomSpawnPos();
        }

        return newPos;
    }
    void SpawnEnemy()
    {
        var newObj = Instantiate(enemyObject);
        newObj.transform.position = GetRandomSpawnPos();
    }
    // Start is called before the first frame update

    /*void LowerCooldown()
    {
        SpawnCooldownSeconds = SpawnCooldownSeconds - 0.05f;
        lala = 1;
        Invoke("Reset", 1f);

    }*/

    /*void Reset()
    {
        lala = 0;
    }*/

    /*void Update()
    {
        if (lala == 0)
        {
            Invoke("LowerCooldown", 0f);
        }

    }*/

    void FixedUpdate()
    {
        SpawnCooldownSeconds -= Time.deltaTime;

        if (SpawnCooldownSeconds <= 0.0f)
        {
            SpawnEnemy();
            SpawnCooldownSeconds = 1f;
        }

    }




}




