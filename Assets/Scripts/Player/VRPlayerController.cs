using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(XROrigin))]
public class VRPlayerController : MonoBehaviour
{
    private CharacterController _cc;
    private XROrigin _xrOrigin;

    [Header("Movement Settings")]
    [SerializeField] private float speed = 3.0f; // VR movement is usually slower than flatscreen
    [SerializeField] private float gravity = -9.81f;
    private float _yVelocity;

    [Header("Turning")]
    [SerializeField] private bool useSnapTurn = true;
    [SerializeField] private float snapRotationAmount = 45f;
    [SerializeField] private float continuousTurnSpeed = 60f;
    private bool _hasTurned;

    [Header("Input Actions")]
    [SerializeField] private InputActionProperty moveAction;
    [SerializeField] private InputActionProperty turnAction;
    [SerializeField] private InputActionProperty interactAction;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _xrOrigin = GetComponent<XROrigin>();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleInteraction();
    }

    private void HandleMovement()
    {
        // 1. Get Thumbstick Input
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // 2. Move relative to where the Headset (Camera) is looking
        Vector3 direction = new Vector3(input.x, 0, input.y);
        Vector3 headRotation = Vector3.ProjectOnPlane(_xrOrigin.Camera.transform.forward, Vector3.up).normalized;
        Quaternion moveRotation = Quaternion.LookRotation(headRotation);

        Vector3 moveVector = moveRotation * direction * speed;

        // 3. Apply Gravity
        if (_cc.isGrounded && _yVelocity < 0)
            _yVelocity = -1f;
        else
            _yVelocity += gravity * Time.deltaTime;

        moveVector.y = _yVelocity;

        // 4. Final Move
        _cc.Move(moveVector * Time.deltaTime);
    }

    private void HandleRotation()
    {
        Vector2 input = turnAction.action.ReadValue<Vector2>();

        if (useSnapTurn)
        {
            // Snap Turning Logic
            if (Mathf.Abs(input.x) > 0.5f)
            {
                if (!_hasTurned)
                {
                    float angle = input.x > 0 ? snapRotationAmount : -snapRotationAmount;
                    _xrOrigin.RotateAroundCameraUsingOriginUp(angle);
                    _hasTurned = true;
                }
            }
            else
            {
                _hasTurned = false;
            }
        }
        else
        {
            // Continuous Turning Logic
            float turnAmount = input.x * continuousTurnSpeed * Time.deltaTime;
            _xrOrigin.RotateAroundCameraUsingOriginUp(turnAmount);
        }
    }

    private void HandleInteraction()
    {
        // Simple check for the 'A' or 'X' button press
        if (interactAction.action.WasPressedThisFrame())
        {
            Debug.Log("VR Interaction Triggered!");
            // Add your interaction logic here (e.g., raycasting to a button)
        }
    }
}