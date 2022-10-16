using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleGolden : MonoBehaviour
{

    //public static int amtCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            Collectible.amtCollected++;
            Collectible.amtCollected++;
            Collectible.amtCollected++;
            Collectible.amtCollected++;
            Collectible.amtCollected++;
            //Debug.Log(amtCollected);
        }
    }
}
