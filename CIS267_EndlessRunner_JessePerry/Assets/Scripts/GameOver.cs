using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;


    // Update is called once per frame
    void Update()
    {
        if(Obstacle.amtHit == 3)
        {
            gameOverPanel.SetActive(true);
            Obstacle.amtHit = 0;
            Time.timeScale = 0;
        }
    }

    public void restart()
    {
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
