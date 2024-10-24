
using UnityEngine;
using UnityEngine.InputSystem;


public class InputManager : MonoBehaviour
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


    //private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    public Vector2 moveInput { get; private set; }
    public bool jumpInput = false;   // should be an event that calls jump instead of a bool


    private void Awake()
    {
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



        // Initialize the input actions
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.Enable();

        // Hook up action callbacks manually
        playerInputActions.Player.Movement.performed += MovePerformed;
        playerInputActions.Player.Movement.canceled += MoveCanceled;

        playerInputActions.Player.Jump.started += JumpStarted;

    }

    private void OnDisable()
    {
        playerInputActions.Disable();

        // Hook up action callbacks manually
        playerInputActions.Player.Movement.performed -= MovePerformed;
        playerInputActions.Player.Movement.canceled -= MoveCanceled;

        playerInputActions.Player.Jump.started -= JumpStarted;

    }

    private void MovePerformed(InputAction.CallbackContext context)
    {
        // Read move input when performed
        moveInput = context.ReadValue<Vector2>();
    }

    private void MoveCanceled(InputAction.CallbackContext context)
    {
        // Read move input when performed
        moveInput = Vector2.zero;
    }

    private void JumpStarted(InputAction.CallbackContext context)
    {
        // Only set jumpInput to true once per press
        jumpInput = true;
    }




}
