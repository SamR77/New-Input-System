using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float jumpForce = 5.0f;
    
    private Rigidbody sphereRigidbdody;



    private void Awake()
    {
        sphereRigidbdody = GetComponent<Rigidbody>();        
    }

    private void Start()
    {
        // inputManager.MoveEvent += HandleMove;
        InputManager.instance.JumpEvent += HandleJump;
    }

    private void HandleJump()
    {
        Debug.Log("Jump Triggered within Sphere Controller with a force of :" + jumpForce);
        sphereRigidbdody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);        
    }


    private void HandleMove(Vector2 moveInput)
    {
        sphereRigidbdody.AddForce(new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed, ForceMode.Force);

    }

}
