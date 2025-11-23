using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;
    [SerializeField] private PlayerController PlayerPrefab;

    private MapManager _gameMap;
    private PlayerController _playerController;

    // Start the game at runtime
    void Start()
    {
        // Game waits for Start button
    }

    // Reset and start the game (called from MainMenu or PauseManager Quit)
    public void ResetGame()
    {
        // Destroy existing map/player
        if (_gameMap != null)
            Destroy(_gameMap.gameObject);
        if (_playerController != null)
            Destroy(_playerController.gameObject);

        // Spawn map
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;
        _gameMap.CreateMap();

        // Spawn player in random room
        var randomStartingRoom = _gameMap.Rooms[Random.Range(0, _gameMap.Size), Random.Range(0, _gameMap.Size)];
        _playerController = Instantiate(PlayerPrefab, transform);
        _playerController.transform.position = new Vector3(randomStartingRoom.transform.position.x, 1, randomStartingRoom.transform.position.z);
        _playerController.Setup();
    }
}