using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    

    // Speed of the enemy's movement
    public float speed = 2.0f;

    Vector3 positionEnemy = new Vector3(0,0,0);

    Transform playerTransform;

    Vector3 positionPlayer;

    // Distance the enemy should stop at
    public float stoppingDistance = 4.0f;

    public float viewDistance = 10.0f;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        Vector3 positionPlayer = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        Vector3 positionPlayer = playerTransform.position;

        float distance = Vector3.Distance(positionPlayer, transform.position);


        positionEnemy = transform.position;
        if (distance < viewDistance)
        {
            if (positionEnemy != positionPlayer && Vector3.Distance(positionEnemy, positionPlayer) > stoppingDistance)
            {
                Vector3 direction = (positionPlayer - positionEnemy).normalized;
                transform.position += direction * speed * Time.deltaTime;

            } 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positionPlayer - transform.position), Time.deltaTime * 5.0f);

        }
    }
}