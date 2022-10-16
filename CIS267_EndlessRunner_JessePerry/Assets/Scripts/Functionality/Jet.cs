using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{
    private float x;
    private float y;
    private Rigidbody2D rb;
    private float spawnTime;
    private static float changeDirectionDelay;


    //PlayerController temp = new PlayerController();
    // Start is called before the first frame update
    void Start()
    {
        changeDirectionDelay = .4f;

        GameObject player = GameObject.FindGameObjectWithTag("PlayerBorder");

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Time.time > spawnTime)
        {
            x = Random.Range(-10, 0);
            y = Random.Range(0, 1);

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
            Obstacle.amtHit++;
            HeartControl.health--;
            Destroy(this.gameObject);
        }
    }
}
