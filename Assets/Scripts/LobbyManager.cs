using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{

    public void LoadScene()
    {
        SceneManager.LoadScene("Level 01");
    }
}