using UnityEngine;

public class ElevatorUp : MonoBehaviour
{
    public Transform Elevator;
    public float ElevatorSpeed = 2f;
    public float ElevatorHeight = 5f;

    private bool shouldMove = false;
    private Vector3 targetPosition;

    void Start()
    {
        if (Elevator != null)
        {
            targetPosition = Elevator.position;
        }
    }


    void Update()
    {
        if (shouldMove && Elevator != null)
        {
            Elevator.position = Vector3.MoveTowards(Elevator.position, targetPosition, ElevatorSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetPosition = Elevator.position + new Vector3(0, ElevatorHeight, 0);
            shouldMove = true;
            Debug.Log("Player Collision");
        }
        Debug.Log("Collision");
    }

}