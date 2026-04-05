using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private LobbyManager lobbyManager;
    public string nextLevel = "";
    public string loadLobby = "";

    private HintMSG hintMSG;

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
        hintMSG = FindAnyObjectByType<HintMSG>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        bool hasAnomaly = false;

        if (levelManager != null)
        {
            hasAnomaly = levelManager.HasAnomaly();
        }

        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        if (hasAnomaly && eType == elevatorType.anamoly)
        {
            SceneLoader.LoadScene(nextLevel);
            hintMSG.resetText();
        }
        else if (!hasAnomaly && eType == elevatorType.anamoly)
        {
            SceneLoader.LoadScene(loadLobby);
            hintMSG.noAnamolyChangeText();
        }
        else if (!hasAnomaly && eType == elevatorType.noanamoly)
        {
            SceneLoader.LoadScene(nextLevel);
            hintMSG.resetText();
        }
        else if (hasAnomaly && eType == elevatorType.noanamoly)
        {
            SceneLoader.LoadScene(loadLobby);
            hintMSG.ChangeText();
        }
    }
}