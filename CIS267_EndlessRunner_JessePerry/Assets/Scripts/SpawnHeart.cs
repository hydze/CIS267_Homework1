using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{
    public GameObject heart;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if(HeartControl.health < 3)
        {
            timeBetweenSpawn = Random.Range(5, 10);
            if (Time.time > spawnTime)
            {
                spawn();
                spawnTime = Time.time + timeBetweenSpawn;
            }
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(heart, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
