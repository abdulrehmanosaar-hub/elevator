using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private LobbyManager lobbyManager;
    public string nextLevel = "";
    public string loadLobby = "";

    public enum elevatorType
    {
        anamoly,
        noanamoly
    }

    public elevatorType eType;

    private LevelManager levelManager;

    void Awake()
    {
        if (lobbyManager == null)
        {
            lobbyManager = FindFirstObjectByType<LobbyManager>();
        }

        levelManager = FindFirstObjectByType<LevelManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        bool hasAnomaly = false;

        if (levelManager != null)
        {
            hasAnomaly = levelManager.HasAnomaly();
        }

        if (hasAnomaly && eType == elevatorType.anamoly)
        {
            SceneLoader.LoadScene(nextLevel);
        }
        else if (!hasAnomaly && eType == elevatorType.anamoly)
        {
            SceneLoader.LoadScene(loadLobby);
        }
        else if (!hasAnomaly && eType == elevatorType.noanamoly)
        {
            SceneLoader.LoadScene(nextLevel);
        }
        else if (hasAnomaly && eType == elevatorType.noanamoly)
        {
            SceneLoader.LoadScene(loadLobby);
        }
    }
}