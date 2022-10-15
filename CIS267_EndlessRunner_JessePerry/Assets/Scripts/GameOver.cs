using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public static bool isActive;
   //public static bool isClicked;


    // Update is called once per frame
    void Update()
    {
        //isClicked = false;
        if(HeartControl.health == 0)
        {
            gameOverPanel.SetActive(true);
            isActive = true;
            Obstacle.amtHit = 0;
            Time.timeScale = 0;
        }
        else isActive = false;
    }

    public void restart()
    {
        //isClicked = true;
        //ScoreManager.re
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
        //Debug.Log("RAHHHHH");
    }
}
