using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEagle : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private float timeBetweenSpawn;
    private float spawnTime;
    //private bool setGravity = false;

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawn = Random.Range(1, 10);

        if(Time.time > spawnTime && !SpawnObstacles.appleDelay)
        {
            spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
