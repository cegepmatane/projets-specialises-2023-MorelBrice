using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float health;

    public GameOverScreen gameManager;

    bool estTue = false;

    void Awake()
    {
        gameManager.gameOverUI.SetActive(false);
        Time.timeScale = 1;

        health = 100f;

        GameOverScreen.isDead = false;
    }


    void Update()
    {

        Renderer renderer = GetComponent<Renderer>();       

        renderer.material.SetColor("_Color", Color.green);

        HealthUIScript.HealthValue = health;

        if (health <= 0f && !estTue)
        {
            Die();
            estTue = true;
        }
    }

    public static void takeDamage(float amount)
    {
        health -= amount;
    }

    public void Die()
    {
         gameManager.gameOver();
    }
}
