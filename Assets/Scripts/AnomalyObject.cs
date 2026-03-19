using UnityEngine;

public class AnomalyObject : MonoBehaviour
{
    private Vector3 originalPos;
    private Quaternion originalRot;
    public AnomalyData myAnomalyData;

    void Awake()
    {
        originalPos = transform.localPosition;
        originalRot = transform.localRotation;
    }

    public void TriggerAnomaly()
    {
        if (myAnomalyData.shouldBeHidden)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.localPosition += myAnomalyData.targetPositionOffset;
            transform.localRotation *= Quaternion.Euler(myAnomalyData.targetRotationOffset);
        }
    }

    public void ResetToNormal()
    {
        gameObject.SetActive(true);
        transform.localPosition = originalPos;
        transform.localRotation = originalRot;
    }
}