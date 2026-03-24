using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public float minimumLoadTime = 2f;

    void Start()
    {
        if (string.IsNullOrEmpty(SceneLoader.targetScene))
        {
            Debug.LogError("No target scene set.");
            return;
        }

        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneLoader.targetScene);
        operation.allowSceneActivation = false;

        float timer = 0f;

        while (!operation.isDone)
        {
            timer += Time.deltaTime;

            if (operation.progress >= 0.9f && timer >= minimumLoadTime)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}