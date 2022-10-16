using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private float x;
    private float y;
    private Rigidbody2D rb;
    private float spawnTime;
    private static float changeDirectionDelay;
    //private bool enemyDelay;
    public bool hitApple;


    //PlayerController temp = new PlayerController();
    // Start is called before the first frame update
    void Start()
    {
        hitApple = false;
       // enemyDelay = false;
        changeDirectionDelay = .5f;

        GameObject player = GameObject.FindGameObjectWithTag("PlayerBorder");

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (hitApple)
        {
            Invoke("revertBool", 5);
            Debug.Log("made into hitapple update");
        }

        if (Time.time > spawnTime)
        {
            x = Random.Range(-4, 0);
            y = Random.Range(-5, 5);

            rb.velocity = new Vector2(x, y);

            spawnTime = Time.time + changeDirectionDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Player")
        {
            // Debug.Log("made into player before destroy");
            //Debug.Log("made into player past destroy");

            SpawnObstacles.appleDelay = true;
            Destroy(this.gameObject);
            //Debug.Log(SpawnObstacles.appleDelay);
        }
    }

    private void revertBool()
    {
        //enemyDelay = false;
        hitApple = false;
        Debug.Log("made into revert bool function");
    }
}