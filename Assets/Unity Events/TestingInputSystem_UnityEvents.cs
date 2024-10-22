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

    private void Awake()
    {        
        sphereRigidbdody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();        
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

   

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
