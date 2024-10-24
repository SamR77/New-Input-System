using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem_UnityEvents : MonoBehaviour
{
    private Rigidbody sphereRigidbdody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {        
        sphereRigidbdody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();        
        playerInputActions.Player.Enable();        
        playerInputActions.Player.Jump.performed += Jump;
       //playerInputActions.Player.Movement.performed += MovementPerformed;
    }

    private void FixedUpdate()
    {
        MoveSphere();     
    }

    private void MoveSphere()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>(); ;
        float speed = 2.0f;
        sphereRigidbdody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    /*
    private void MovementPerformed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 5.0f;
        sphereRigidbdody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }
    */

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);

        if (context.performed)
        {
            Debug.Log("Jump" + context.phase);
            sphereRigidbdody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        
    }

}
