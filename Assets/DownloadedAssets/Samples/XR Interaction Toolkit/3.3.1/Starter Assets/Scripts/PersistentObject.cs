using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    private void Awake()
    {
        // Keeps this object alive when the scene changes
        DontDestroyOnLoad(gameObject);
    }
}