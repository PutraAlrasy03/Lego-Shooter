using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;
    public float gravity = -9.8f;
    private bool IsGrounded;

    private Vector3 playerVelocity; // Added to track player velocity

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerVelocity = Vector3.zero; // Initialize velocity to zero
    }

    void Update()
    {
        // Check for ground contact using CharacterController.isGrounded
        IsGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 movement = transform.TransformDirection(new Vector3(input.x, 0f, input.y));
        controller.Move(movement * speed * Time.deltaTime);

        // Track vertical velocity for gravity
        playerVelocity.y += gravity * Time.deltaTime;

        // Apply a small upward force when grounded (optional)
        if (IsGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // Adjust this value for desired bounce effect
        }

        // Apply vertical velocity through movement
        controller.Move(playerVelocity * Time.deltaTime);

        Debug.Log(playerVelocity.y);
    }
}
