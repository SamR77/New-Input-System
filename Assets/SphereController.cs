using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float jumpForce = 5.0f;

    private Rigidbody sphereRigidbdody;    

    private void Awake()
    {
        sphereRigidbdody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleJump();
    }


    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleJump()
    {
        if (InputManager.instance.jumpInput) 
        {        
            Debug.Log("jump");
            sphereRigidbdody.AddForce(Vector3.up * 5f, ForceMode.Impulse);

            // have to set the jumpInput to false or it reads the input multiple times, I dont like forceing the bool back from here.
            // should be an event that calls jump instead of a bool
            InputManager.instance.jumpInput = false;
        }
        
        
    }


    private void HandleMovement()
    {
        

        //sphereRigidbdody.AddForce(new Vector3(InputManager.instance.moveInput.x, 0, InputManager.instance.moveInput.y) * moveSpeed, ForceMode.Force);
    }

}
