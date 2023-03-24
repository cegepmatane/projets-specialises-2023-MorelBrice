using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovements : MonoBehaviour
{
    
    public NavMeshAgent agent;

    // Speed of the enemy's movement
    public float speed = 2.0f;

    Vector3 positionEnemy = new Vector3(0,0,0);

    // Transform playerTransform;

    // Vector3 positionPlayer;

    // Distance the enemy should stop at
    public float stoppingDistance = 3.0f;

    public float viewDistance = 10.0f;

    Animator animator;

    float timeStamp;

    private float attackCoolDown = 1.0f;




    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!animator.GetBool("isDead"))
        {
            GameObject player = GameObject.Find("Player");
            Transform playerTransform = player.transform;
            Vector3 positionPlayer = playerTransform.position;

            float distance = Vector3.Distance(positionPlayer, transform.position);

            Vector3 positionEnemy = transform.position;

            animator.SetBool("attackBool", false);


            if (distance < viewDistance)
            {
                if (positionEnemy != positionPlayer && Vector3.Distance(positionEnemy, positionPlayer) > stoppingDistance)
                {
                    agent.Resume();

                    // Vector3 direction = (positionPlayer - positionEnemy).normalized;
                    // transform.position += direction * speed * Time.deltaTime;

                    agent.SetDestination(positionPlayer);
                    // Debug.Log("j'avance");
                    animator.SetBool("isWalking", true);

                } 
                else
                {
                    animator.SetBool("isWalking", false);
                    agent.Stop();
                    // Debug.Log("j'arrête");

                    if (Vector3.Distance(positionEnemy, positionPlayer) <= stoppingDistance)
                    {
                        animator.SetBool("attackBool", true);
                    }
                }
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positionPlayer - transform.position), Time.deltaTime * 5.0f);
            }
        }
        else
        {
            GameObject player = GameObject.Find("Player");

            GetComponent<CapsuleCollider>().enabled = false;

        }
    }

    void attack()
            {

                GameObject player = GameObject.Find("Player");
                Transform playerTransform = player.transform;
                Vector3 positionPlayer = playerTransform.position;

                float distance = Vector3.Distance(positionPlayer, transform.position);

                Vector3 positionEnemy = transform.position;
                
                if (Vector3.Distance(positionEnemy, positionPlayer) <= stoppingDistance)
                {
                    PlayerHealth.takeDamage(10.0f);
                }
            }
}