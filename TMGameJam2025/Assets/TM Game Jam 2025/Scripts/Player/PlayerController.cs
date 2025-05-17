using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions controls; 
    private Vector2 moveInput; 
    private Rigidbody rb; 
    public float moveSpeed = 5f; 
    public float rotationSpeed = 180f; 

    void Awake()
    {
        // Input system
        controls = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        // Action Map
        controls.Player.Enable();
        
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
    }

    void OnDisable()
    {
        // Disable while no inputs
        controls.Player.Disable();
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;
    }

    /// <summary>
    /// Callback reads the input value from the Input System (MOVE)
    /// </summary>
    /// <param name="context"></param>
    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // Forward and Backward Movement (W/S)
        float moveAxis = moveInput.y; // W: 1, S: -1
        if (Mathf.Abs(moveAxis) > 0.1f)
        {
            // Moves forward/backward in the direction the player is facing
            Vector3 moveDirection = transform.forward * moveAxis;
            Vector3 moveVelocity = moveDirection * moveSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }

        // Rotation (A/D)
        float rotateAxis = moveInput.x; // A: -1, D: 1
        if (Mathf.Abs(rotateAxis) > 0.1f)
        {
            float rotationDelta = rotateAxis * rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(0f, rotationDelta, 0f);
        }
    }
}