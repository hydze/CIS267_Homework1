using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBanana : MonoBehaviour
{
    public GameObject banana;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private float timeBetweenSpawn;
    private float spawnTime = 10;

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawn = Random.Range(10, 30);
        if (Time.time > spawnTime)
        {
            spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(banana, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
