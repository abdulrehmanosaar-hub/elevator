using UnityEngine;

public class ElevatorButton : MonoBehaviour, IInteractable
{
    public ElevatorController elevator;

    public enum ButtonType
    {
        OpenDoors,
        StartElevator
    }

    public ButtonType buttonType;

    public void Interact()
    {
        if (elevator == null) return;

        if (buttonType == ButtonType.OpenDoors)
        {
            elevator.OpenDoors();
        }
        else if (buttonType == ButtonType.StartElevator)
        {
            elevator.StartElevator();
        }
    }
}



// using UnityEngine;
// using UnityEngine.InputSystem;

// public class ElevatorButton : MonoBehaviour
// {
//     public ElevatorController elevator;

//     public enum ButtonType
//     {
//         OpenDoors,
//         StartElevator
//     }

//     public ButtonType buttonType;

//     private bool playerNearby = false;

//     public void OnInteract(InputAction.CallbackContext context)
//     {
//         if (!context.performed) return;
//         if (!playerNearby) return;
//         if (elevator == null) return;

//         if (buttonType == ButtonType.OpenDoors)
//         {
//             elevator.OpenDoors();
//         }
//         else if (buttonType == ButtonType.StartElevator)
//         {
//             elevator.StartElevator();
//         }
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//             playerNearby = true;
//     }

//     void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//             playerNearby = false;
//     }
// }