
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IGameplayActions
{
   
    #region Static instance
    // Public static property to access the singleton instance of GameStateManager
    public static InputManager instance
    {
        get
        {
            // If the instance is not set, instantiate a new one from resources
            if (_instance == null)
            {
                // Loads the GameStateManager prefab from Resources folder and instantiates it
                var go = (GameObject)GameObject.Instantiate(Resources.Load("InputManager"));
            }
            // Return the current instance (if set) or the newly instantiated instance
            return _instance;
        }
        // Private setter to prevent external modification of the instance
        private set { }
    }
    // Private static variable to hold the singleton instance of GameStateManager
    private static InputManager _instance;
    #endregion
 

    public GameInput gameInput;


    private void Awake()
    {
        // Initialize the GameInput instance
        gameInput = new GameInput();

        // Register this class to receive input callbacks
        gameInput.Gameplay.SetCallbacks(this);
                
        #region Singleton Pattern
        // If there is an instance, and it's not me, delete myself.
        if (_instance != null)
        {
        Destroy(gameObject);
        return;
         }
        _instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion        
    }

    private void OnEnable()
    {
        // Enable the input system
        gameInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        // Disable the input system when the object is disabled
        gameInput.Gameplay.Disable();
    }

    #region Input Events

    public event Action JumpEvent;
    public event Action<Vector2> MoveEvent;
      
    #endregion



    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("jump performed");
            JumpEvent?.Invoke();
        }        
    }

    public void OnMovement(InputAction.CallbackContext context)
    {      
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
            Debug.Log("movement performed");      
    }
}
