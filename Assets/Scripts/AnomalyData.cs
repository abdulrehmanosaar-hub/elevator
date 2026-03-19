using UnityEngine;

[CreateAssetMenu(fileName = "New Anomaly", menuName = "Elevator/Anomaly")]
public class AnomalyData : ScriptableObject
{
    public string anomalyID;
    [TextArea] public string description; // "The red cup is on the floor"

    // We can store original vs. changed states here
    public Vector3 targetPositionOffset;
    public Vector3 targetRotationOffset;
    public bool shouldBeHidden = false;
}