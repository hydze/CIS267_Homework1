using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if (HeartControl.health != 0)
        {
            scoreText.text = Collectible.amtCollected.ToString();
        }
    }

    public void resetScore()
    {
            scoreText.text = "0";
            Collectible.amtCollected = 0;
    }
}
