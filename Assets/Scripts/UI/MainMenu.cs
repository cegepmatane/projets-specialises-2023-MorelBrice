using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jouer()
    {
        SceneManager.LoadScene("dev");
    }

    public void Quitter()
    {
        Application.Quit();
    }
}