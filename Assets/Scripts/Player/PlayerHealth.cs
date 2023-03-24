using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100f;

    public GameOverScreen gameManager;


    void Update()
    {

        Renderer renderer = GetComponent<Renderer>();       

        renderer.material.SetColor("_Color", Color.green);

        HealthUIScript.HealthValue = health;

        if (health <= 0f)
        {
            Die();
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
