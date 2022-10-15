using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleE : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "PlayerBorder")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (collision.tag == "Respawn")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        else if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            Obstacle.amtHit++;
            HeartControl.health--;
            //Debug.Log(amtHit);
        }
    }
}