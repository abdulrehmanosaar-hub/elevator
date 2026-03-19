using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerZoom : MonoBehaviour
{
    [Header("Camera")]
    public Camera playerCamera;

    [Header("Zoom Settings")]
    public float zoomFov = 40f;
    public float zoomSpeed = 8f;

    private float defaultFov;
    private bool isZooming;

    private void Start()
    {
        if (playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>();

        defaultFov = playerCamera.fieldOfView;
    }

    private void Update()
    {
        float targetFov = isZooming ? zoomFov : defaultFov;

        playerCamera.fieldOfView = Mathf.Lerp(
            playerCamera.fieldOfView,
            targetFov,
            Time.deltaTime * zoomSpeed
        );
    }

    // Input System (Right Click)
    public void Zoom(InputAction.CallbackContext context)
    {
        isZooming = context.ReadValueAsButton();
    }
}