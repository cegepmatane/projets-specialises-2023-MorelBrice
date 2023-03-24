using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public NavMeshAgent agent;
    Animator animator;




    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();  

        animator = GetComponent<Animator>();

    }

    public void takeDamage(float amount)
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        animator.SetTrigger("tookDamage");

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        // Destroy(gameObject);
        animator.SetBool("isDead", true);
    }
}
