using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab;

    private MapManager _gameMap;
    private PlayerController _playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Debug.Log("GameManager Start Begins");
        // 
        transform.position = Vector3.zero;
        SetupMap();
        SpawnPlayer();
        StartGame();
        Debug.Log("GameManager Start Complete");
    }

    private void SetupMap()
    {

        Debug.Log("GameManager SetupMap Begins");
        // create an instance
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        // create map
        _gameMap.CreateMap();
        Debug.Log("GameManager Map Created");

    }
    private void SpawnPlayer()
    {
        // Intro
        Debug.Log("GameManager SpawnPlayer Begins");
        // Pick random starting room
        var randomStartingRoom = _gameMap.Rooms[Random.Range(0, _gameMap.Size), Random.Range(0, _gameMap.Size)];
        // Create player
        _playerController = Instantiate(PlayerPrefab, transform);
        // Set initial position
        _playerController.transform.position = new Vector3(randomStartingRoom.transform.position.x, 1, randomStartingRoom.transform.position.z);
        // Call Player Setup Function
        _playerController.Setup();
        Debug.Log("GameManager SpawnPlayer Complete");
    }
    private void StartGame()
    {
        Debug.Log("GameManager StartGame Begins");
        Debug.Log("GameManager StartGame Complete");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
