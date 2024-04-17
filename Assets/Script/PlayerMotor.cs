using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 movement = transform.TransformDirection(new Vector3(input.x, 0f, input.y));
        controller.Move(movement * speed * Time.deltaTime);
    }
}


