using UnityEngine;
using UnityEngine.InputSystem;

public class FlashLight : MonoBehaviour
{
    public Light flashlight;


    void Awake()
    {
        flashlight.enabled = false;
    }

    public void OnToggleLight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
