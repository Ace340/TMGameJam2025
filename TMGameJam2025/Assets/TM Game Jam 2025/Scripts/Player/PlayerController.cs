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

    void Awake()
    {
        controls = new PlayerInputActions();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        lastPosition = transform.position;
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

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        RotateTowardsMouse();
        AnimatePlayer();
        lastPosition = transform.position;
    }

    private void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(-moveInput.y, 0f, moveInput.x);

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            moveDirection = moveDirection.normalized;
            Vector3 moveVelocity = moveDirection * moveSpeed;
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }


    //Move Player Juanki
    // private void MovePlayer()
    // {

    //     float moveAxis = moveInput.y; // W: 1, S: -1
    //     if (Mathf.Abs(moveAxis) > 0.1f)
    //     {
    //         Vector3 moveDirection = transform.forward * moveAxis;
    //         Vector3 moveVelocity = moveDirection * moveSpeed;
    //         rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    //     }

    //     float rotateAxis = moveInput.x; // A: -1, D: 1
    //     if (Mathf.Abs(rotateAxis) > 0.1f)
    //     {
    //         float rotationDelta = rotateAxis * rotationSpeed * Time.fixedDeltaTime;
    //         transform.Rotate(0f, rotationDelta, 0f);
    //     }
    // }

    private void AnimatePlayer()
    {
        animator.SetBool("IsWalking", CalculatePlayerSpeed() > 0);
    }

    private float CalculatePlayerSpeed()
    {
        return (transform.position - lastPosition).magnitude / Time.fixedDeltaTime;
    }



    private void RotateTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // y=0

        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            Vector3 direction = hitPoint - transform.position;
            direction.y = 0f;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20f * Time.deltaTime);
            }
        }
    }
}
