using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MapManager GameMapPrefab;

    private MapManager _gameMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Debug.Log("GameManager Start");
        // 
        transform.position = Vector3.zero;

        // create an instance
        _gameMap = Instantiate(GameMapPrefab, transform);
        _gameMap.transform.position = Vector3.zero;

        _gameMap.CreateMap();

        Debug.Log("GameManager Map Created");

    }
    private void StartGame()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
