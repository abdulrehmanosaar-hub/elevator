using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<AnomalyObject> allPossibleAnomalies;

    // We keep this private so other scripts use the method to check it
    private bool isCurrentFloorAnomaly = false;

    // 1. Trigger the logic as soon as the scene loads
    void Start()
    {
        PrepareNextFloor();
    }

    public void PrepareNextFloor()
    {
        // Safety check to ensure the list isn't empty
        if (allPossibleAnomalies == null || allPossibleAnomalies.Count == 0)
        {
            Debug.LogWarning("LevelManager: No anomalies assigned in the Inspector!");
            return;
        }

        // 1. Reset everything to the "Normal" state first
        foreach (var obj in allPossibleAnomalies)
        {
            if (obj != null) obj.ResetToNormal();
        }

        // 2. 50/50 chance of being an anomaly floor
        isCurrentFloorAnomaly = Random.value > 0.4f;

        if (isCurrentFloorAnomaly)
        {
            // Pick ONE random object to change
            int randomIndex = Random.Range(0, allPossibleAnomalies.Count);
            allPossibleAnomalies[randomIndex].TriggerAnomaly();
            Debug.Log("<color=orange>Anomaly Active:</color> " + allPossibleAnomalies[randomIndex].name);
        }
        else
        {
            Debug.Log("<color=white>Normal Floor Generated.</color>");
        }
    }

    // 2. The method for your Elevator to check the result
    public bool HasAnomaly()
    {
        return isCurrentFloorAnomaly;
    }
}