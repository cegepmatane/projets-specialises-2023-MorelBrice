using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Speed of the player's movement
    public float speed = 10.0f;

    // Speed of the player's movement while sprinting 
    public float sprint = 12.0f;

    // Acceleration speed
    public float acc = 1.0f;

    // Current speed
    public float curr_speed = 1.0f;

    // The character controller component attached to the player
    private CharacterController characterController;

    // The transform component attached to the player
    private Transform playerTransform;

    // The force of gravity
    public float gravity = 9.81f;

    // A vector to store the player's velocity
    private Vector3 velocity;

    private bool jump;

    // The force of jump
    private float jumpforce = 5.0f;

    private Vector3 LatestRecordedMovementDir = Vector3.zero;

    void Start()
    {
        // Get references to the character controller and transform components
        characterController = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create a vector to store the desired movement direction
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // Normalize the vector so the player moves at a consistent speed
        moveDirection = moveDirection.normalized;

        // Rotate the player based on its own rotation
        moveDirection = playerTransform.rotation * moveDirection;

        // Multiply the vector by the speed to get the desired speed
        moveDirection *= speed;
        

        //Sprint function
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection /= speed;
            moveDirection *= sprint;
        }

        // Apply gravity to the player's velocity
        velocity.y -= gravity * Time.deltaTime;

        // Move the character controller in the desired direction
        characterController.Move(moveDirection * Time.deltaTime + velocity * Time.deltaTime);

         // If the player is on the ground, allow movement input
        if (characterController.isGrounded)
        {
            // Reset the velocity y to 0 so that the player doesn't accumulate velocity while on the ground
            velocity.y = 0;

            // Check if the player is jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if(jump)
        {
            velocity.y = jumpforce;
            jump = false;
        }
    }


    public class collisions : MonoBehaviour
{
    // this script pushes all rigidbodies that the character touches
    float pushPower = 2.0f;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}
}