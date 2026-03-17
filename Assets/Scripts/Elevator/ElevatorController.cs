using System.Collections;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    [Header("Doors")]
    public Transform leftDoor;
    public Transform rightDoor;

    [Header("Door Settings")]
    public float doorSpeed = 3f;
    public float leftClosedX = -0.3f;
    public float rightClosedX = 0.3f;
    public float leftOpenX = -1f;
    public float rightOpenX = 1f;

    [Header("Elevator Move")]
    public float moveSpeed = 2f;
    public float targetY = 10f;
    public float waitBeforeMove = 2f;

    private float leftTargetX;
    private float rightTargetX;
    private bool movingElevator = false;
    private bool busy = false;

    private Vector3 lastPosition;
    private PlayerControl playerOnElevator;

    void Start()
    {
        CloseDoors();
        lastPosition = transform.position;
    }

    void Update()
    {
        MoveDoor(leftDoor, leftTargetX);
        MoveDoor(rightDoor, rightTargetX);

        if (movingElevator)
        {
            Vector3 pos = transform.position;
            pos.y = Mathf.MoveTowards(pos.y, targetY, moveSpeed * Time.deltaTime);
            transform.position = pos;

            if (Mathf.Abs(transform.position.y - targetY) < 0.01f)
            {
                pos.y = targetY;
                transform.position = pos;
                movingElevator = false;
                busy = false;
            }
        }

        Vector3 elevatorDelta = transform.position - lastPosition;

        if (playerOnElevator != null)
        {
            playerOnElevator.MoveWithPlatform(elevatorDelta);
        }

        lastPosition = transform.position;
    }

    void MoveDoor(Transform door, float targetX)
    {
        Vector3 pos = door.localPosition;
        pos.x = Mathf.MoveTowards(pos.x, targetX, doorSpeed * Time.deltaTime);
        door.localPosition = pos;
    }

    public void OpenDoors()
    {
        if (busy) return;

        leftTargetX = leftOpenX;
        rightTargetX = rightOpenX;
    }

    public void CloseDoors()
    {
        leftTargetX = leftClosedX;
        rightTargetX = rightClosedX;
    }

    public void StartElevator()
    {
        if (busy) return;
        StartCoroutine(CloseDoorsThenMove());
    }

    IEnumerator CloseDoorsThenMove()
    {
        busy = true;
        CloseDoors();
        yield return new WaitForSeconds(waitBeforeMove);
        movingElevator = true;
    }

    public void SetPlayerOnElevator(PlayerControl player)
    {
        playerOnElevator = player;
    }

    public void ClearPlayerOnElevator(PlayerControl player)
    {
        if (playerOnElevator == player)
            playerOnElevator = null;
    }
}