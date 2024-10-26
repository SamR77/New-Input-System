using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;


    private Rigidbody sphereRigidbdody;

    private Vector2 moveDirection;

    private void Awake()
    {
        sphereRigidbdody = GetComponent<Rigidbody>();
    }

    private void Start()
    {        
        InputManager.instance.JumpEvent += HandleJump;
        InputManager.instance.MoveEvent += HandleMove;
        
        // example of how to enable and disable input..
        // useful for disabling certain inputs in the Enter/Exit methods of a state machine
        
        // InputManager.instance.gameInput.Gameplay.Jump.Enable();
        // InputManager.instance.gameInput.Gameplay.Jump.Disable();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(moveDirection == Vector2.zero)
        {
            return;
        }
        sphereRigidbdody.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y) * moveSpeed, ForceMode.Force);
    }

    private void HandleMove(Vector2 moveInput)  // might want to rename this method to something like HandleMoveInput or something related to just passing storing the input values.
    {
        moveDirection = moveInput;        
    }

    private void HandleJump()
    {
        Debug.Log("Jump Triggered within Sphere Controller with a force of :" + jumpForce);
        sphereRigidbdody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
