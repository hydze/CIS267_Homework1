using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectiblesGolden : MonoBehaviour
{
    public GameObject collectible;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    private float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawn = Random.Range(15, 50);
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

        Instantiate(collectible, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
