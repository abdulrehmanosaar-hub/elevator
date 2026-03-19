using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    [Header("Player")]
    public GameObject playerPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        SpawnPlayerIfNeeded();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SpawnPlayerIfNeeded();
    }

    private void SpawnPlayerIfNeeded()
    {
        PlayerControl existingPlayer = FindObjectOfType<PlayerControl>();

        if (existingPlayer != null)
        {
            Debug.Log("Player already exists, not spawning.");
            return;
        }

        GameObject spawnObj = GameObject.FindGameObjectWithTag("SpawnPoint");

        Vector3 pos = Vector3.zero;
        Quaternion rot = Quaternion.identity;

        if (spawnObj != null)
        {
            pos = spawnObj.transform.position;
            rot = spawnObj.transform.rotation;
        }
        else
        {
            Debug.LogWarning("No SpawnPoint found in scene. Using world origin.");
        }

        Instantiate(playerPrefab, pos, rot);
        Debug.Log("Player spawned in scene: " + SceneManager.GetActiveScene().name);
    }


    public void LoadScene()
    {
        SceneManager.LoadScene("Level 01");
        SpawnPlayerIfNeeded();
    }
}


















