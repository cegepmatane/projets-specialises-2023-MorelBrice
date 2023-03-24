using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverUI;

    public int scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    public void gameOver() 
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void respawn()
    {
        gameOverUI.SetActive(false);
         SceneManager.LoadScene(scene);
    }
}
