using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverUI;

    public static bool isDead = false;
    void Start()
    {
    }

    public void gameOver() 
    {
        Debug.Log("game Over");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        isDead = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void respawn()
    {
        gameOverUI.SetActive(false);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("dev 1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
