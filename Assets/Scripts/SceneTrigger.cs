using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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

        levelManager = FindObjectOfType<LevelManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool hasAnomaly = false;

            if (levelManager != null)
            {
                hasAnomaly = levelManager.HasAnomaly();
            }

            if (hasAnomaly && (eType == elevatorType.anamoly))
            {
                SceneManager.LoadScene(nextLevel);
            }
            else if (!hasAnomaly && (eType == elevatorType.anamoly))
            {
                SceneManager.LoadScene(loadLobby);
            }
            else if (!hasAnomaly && (eType == elevatorType.noanamoly))
            {
                SceneManager.LoadScene(nextLevel);
            }
            else if (hasAnomaly && (eType == elevatorType.noanamoly))
            {
                SceneManager.LoadScene(loadLobby);
            }


        }
    }


}