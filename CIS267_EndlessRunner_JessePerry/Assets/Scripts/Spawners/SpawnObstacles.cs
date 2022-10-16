using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

    public GameObject obstacle;
    public float maxX;
    public float minX;
    public float Y;
    private float timeBetweenSpawn;
    private float spawnTime;
    public static bool appleDelay;

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawn = Random.Range(1, 8);
        if (appleDelay)
        {
            Debug.Log("inside if appledelay");
            Invoke("resetDelay", 10);
        }

        if (Time.time > spawnTime && !appleDelay)
        {
            spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void spawn()
    {
        float randomX = Random.Range(minX, maxX);

        Instantiate(obstacle, transform.position + new Vector3(randomX, Y, 0), transform.rotation);
    }

    void resetDelay()
    {
        Debug.Log("inside resetdelay");
        appleDelay = false;
    }
}
