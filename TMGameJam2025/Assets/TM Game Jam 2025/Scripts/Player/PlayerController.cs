using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    [SerializeField] Animator animator;

    private PlayerInputActions controls;
    private Vector2 moveInput;
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Awake()
    {
        controls = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;
    }

    void OnDisable()
    {
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
        MovePlayer();
        AnimatePlayer();

        lastPosition = transform.position;
    }



    private void MovePlayer()
    {

        float moveAxis = moveInput.y; // W: 1, S: -1
        if (Mathf.Abs(moveAxis) > 0.1f)
        {
            Vector3 moveDirection = transform.forward * moveAxis;
            Vector3 moveVelocity = moveDirection * moveSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }

        float rotateAxis = moveInput.x; // A: -1, D: 1
        if (Mathf.Abs(rotateAxis) > 0.1f)
        {
            float rotationDelta = rotateAxis * rotationSpeed * Time.fixedDeltaTime;
            transform.Rotate(0f, rotationDelta, 0f);
        }
    }

    private void AnimatePlayer()
    {
        if (CalculatePlayerSpeed() > 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {

            animator.SetBool("IsWalking", false);
        }
    }

    private float CalculatePlayerSpeed()
    {
        float currentSpeed = (transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
        return currentSpeed;
    }
}