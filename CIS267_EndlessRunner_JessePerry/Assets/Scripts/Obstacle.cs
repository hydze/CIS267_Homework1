using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public static int amtHit;
    public static int damage;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        //GameObject ob2 = GameObject.FindGameObjectWithTag("Player");
        //var nc = new HeartSystem();

        GameObject player = GameObject.FindGameObjectWithTag("PlayerBorder");

        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        else if(collision.tag == "Player")
        {
            
            Destroy(this.gameObject);
            amtHit++;
            HeartControl.health--;
            //HeartSystem.life -= 1;
            //Debug.Log(amtHit);
        }
    }
}