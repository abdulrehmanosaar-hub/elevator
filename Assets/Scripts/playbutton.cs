using UnityEngine;

public class PlayButton : MonoBehaviour, IInteractable
{
    public string sceneName;

    public void Interact()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("Scene name not set on " + gameObject.name);
            return;
        }

        SceneLoader.LoadScene(sceneName);
    }
}