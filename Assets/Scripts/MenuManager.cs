using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}