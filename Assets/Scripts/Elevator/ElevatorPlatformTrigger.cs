using UnityEngine;

public class ElevatorPlatformTrigger : MonoBehaviour
{
    public ElevatorController elevator;

    private void OnTriggerEnter(Collider other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player != null)
        {
            elevator.SetPlayerOnElevator(player);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();

        if (player != null)
        {
            elevator.ClearPlayerOnElevator(player);
        }
    }
}