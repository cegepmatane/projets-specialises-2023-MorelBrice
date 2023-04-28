using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float health = 30f;

    public NavMeshAgent agent;
    Animator animator;

    public Material MatDefault;

    public Material MatDamage;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // animator = GetComponent<Animator>();

    }

    public void takeDamage(float amount)
    {

        StartCoroutine(turnRed());

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

    private IEnumerator turnRed()
    {

        gameObject.GetComponent<Renderer>().material = MatDamage;
        yield return new WaitForSeconds(2.0f);
    }

}
