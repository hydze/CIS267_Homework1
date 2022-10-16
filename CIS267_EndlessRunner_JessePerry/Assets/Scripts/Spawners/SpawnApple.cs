using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    public GameObject apple;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private float timeBetweenSpawns;
    private float spawnTime = 10;

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawns = Random.Range(10, 30);
        if (Time.time > spawnTime)
        {
            spawn();
            spawnTime = Time.time + timeBetweenSpawns;
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(apple, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
