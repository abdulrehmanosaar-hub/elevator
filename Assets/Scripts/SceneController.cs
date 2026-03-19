using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    private void Awake()
    {
        // If another instance already exists, destroy this one
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set singleton reference
        Instance = this;

        // Persist across scenes
        DontDestroyOnLoad(gameObject);
    }
}