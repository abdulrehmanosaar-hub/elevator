using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private LobbyManager lobbyManager;
    public string sceneToLoad = "";

    void Awake()
    {
        if (lobbyManager == null)
        {
            lobbyManager = FindFirstObjectByType<LobbyManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}