using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static string targetScene;

    public static void LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("Scene name is empty.");
            return;
        }

        targetScene = sceneName;
        SceneManager.LoadScene("Loading");
    }
}