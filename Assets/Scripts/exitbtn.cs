using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitbtn : MonoBehaviour, IInteractable
{

    public string sceneName;

    public void Interact()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            Debug.Log("Scene name is not set. Please set the scene name in the inspector.");
        }
        Debug.Log("Exiting the game...");
        Application.Quit();
        
    }
}